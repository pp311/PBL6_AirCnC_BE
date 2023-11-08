using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Application.Services.Cancellations.Dtos;
using AirCnC.Application.Services.Cancellations.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.BookingCancellationException;
using AutoMapper;

namespace AirCnC.Application.Services.Cancellations;

public interface ICancellationService
{
    Task<GetCancellationDto> CreateCancellationTicketAsync(CreateCancellationDto dto); 
    Task<PagedList<GetCancellationDto>> GetCancellationTicketsAsync(CancellationTicketQueryParameters ctp);
    Task<GetCancellationDto> GetCancellationTicketAsync(int cancellationTicketId);
    Task RejectCancellationTicketAsync(int cancellationTicketId, RejectCancellationTicketDto dto);
    Task AcceptCancellationTicketAsync(int cancellationTicketId, AcceptCancellationTicketDto dto);
}

public class CancellationService : ICancellationService
{
    private readonly IRepository<CancellationTicket> _cancellationTicketsRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IRepository<Host> _hostRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public CancellationService(IRepository<CancellationTicket> cancellationTicketsRepository,
                               IMapper mapper,
                               IUnitOfWork unitOfWork,
                               IRepository<Booking> bookingRepository,
                               ICurrentUser currentUser,
                               IRepository<Guest> guestRepository,
                               IRepository<Host> hostRepository)
    {
        _cancellationTicketsRepository = cancellationTicketsRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _bookingRepository = bookingRepository;
        _currentUser = currentUser;
        _guestRepository = guestRepository;
        _hostRepository = hostRepository;
    }

    public async Task<GetCancellationDto> CreateCancellationTicketAsync(CreateCancellationDto dto)
    {
        var booking = await ValidateCreateCancellation(dto);

        var cancellationTicket = _mapper.Map<CancellationTicket>(dto);

        cancellationTicket.Status = CancellationTicketStatus.Pending;
        cancellationTicket.IsIssuerGuest = dto.IsGuest;
        cancellationTicket.TheOtherPartyId = dto.IsGuest ? booking.Property.HostId : booking.GuestId;
        var today = DateTime.UtcNow.Date;
        
        if (booking.CheckInDate.Date >= today && booking.Status is BookingStatus.CheckedIn)
            cancellationTicket.Type = CancellationTicketType.CancelledAfterCheckIn;
        else if (booking.CheckInDate.Date >= today && booking.CheckInDate.Date >= today.AddDays(-2))
            cancellationTicket.Type = CancellationTicketType.CancelledAfterCheckIn;
        else
            cancellationTicket.Type = CancellationTicketType.CancelledBefore2Days;
        
        // Todo: Calculate refund amount and charge amount
        
        _cancellationTicketsRepository.Add(cancellationTicket);
        await _unitOfWork.SaveChangesAsync(); 
        
        return _mapper.Map<GetCancellationDto>(cancellationTicket);
    }

    public async Task<PagedList<GetCancellationDto>> GetCancellationTicketsAsync(CancellationTicketQueryParameters ctp)
    {
        var (cancellationTickets, totalCount) = await _cancellationTicketsRepository
                                                    .FindWithTotalCountAsync(new GetCancellationsSpecification(ctp));
        var cancellationTicketsDto = _mapper.Map<List<GetCancellationDto>>(cancellationTickets);
        return new PagedList<GetCancellationDto>(cancellationTicketsDto, totalCount, ctp.PageIndex, ctp.PageSize);
    }

    public async Task<GetCancellationDto> GetCancellationTicketAsync(int cancellationTicketId)
    {
        var cancellationTicket = await _cancellationTicketsRepository
                                     .FindOneAsync(new CancellationByIdSpecification(cancellationTicketId))
                                 ?? throw new EntityNotFoundException(nameof(CancellationTicket), cancellationTicketId.ToString());
        return _mapper.Map<GetCancellationDto>(cancellationTicket); 
    }

    public async Task RejectCancellationTicketAsync(int cancellationTicketId, RejectCancellationTicketDto dto)
    {
        await UpdateCancellationTicketAsync(cancellationTicketId, dto.ResolveNote, CancellationTicketStatus.Rejected);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AcceptCancellationTicketAsync(int cancellationTicketId, AcceptCancellationTicketDto dto)
    {
        var cancellationTicket = await UpdateCancellationTicketAsync(cancellationTicketId, dto.ResolveNote, CancellationTicketStatus.Resolved);
        
        var booking = await _bookingRepository.FindOneAsync(new BookingByIdSpecification(cancellationTicket.BookingId))
                      ?? throw new EntityNotFoundException(nameof(Booking), cancellationTicket.BookingId.ToString());
        
        booking.Status = cancellationTicket.CreatedAt < booking.CheckInDate 
                             ? BookingStatus.CancelledBeforeCheckIn 
                             : BookingStatus.CancelledAfterCheckIn; 
        
        await _unitOfWork.SaveChangesAsync();
    }
    
    private async Task<CancellationTicket> UpdateCancellationTicketAsync(int cancellationId, string? resolveNote, CancellationTicketStatus status)
    {
        var cancellationTicket = await  _cancellationTicketsRepository
                                     .FindOneAsync(new CancellationByIdSpecification(cancellationId))
                                 ?? throw new EntityNotFoundException(nameof(CancellationTicket), cancellationId.ToString());
        
        if (cancellationTicket.Status is not CancellationTicketStatus.Pending)
            throw new BookingCancellationException("You can only reject pending cancellation tickets.");
        
        cancellationTicket.Status = status;
        cancellationTicket.ResolveNote = resolveNote;

        return cancellationTicket;
    }

    private async Task<Booking> ValidateCreateCancellation(CreateCancellationDto dto)
    {
        var booking = await _bookingRepository.FindOneAsync(new BookingByIdSpecification(dto.BookingId))
                      ?? throw new EntityNotFoundException(nameof(Booking), dto.BookingId.ToString());

        if (booking.Status is
            BookingStatus.Completed or
            BookingStatus.CancelledBeforeCheckIn or
            BookingStatus.CancelledAfterCheckIn or
            BookingStatus.Rejected)
            throw new BookingCancellationException("You can only cancel bookings that have not ended yet.");

        var currentUserId = int.Parse(_currentUser.Id!);
        if (dto.IsGuest)
        {
            var guest = await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(currentUserId))
                        ?? throw new EntityNotFoundException(nameof(Guest), currentUserId.ToString());

            if (booking.GuestId != guest.Id)
                throw new BookingCancellationException("You can only cancel your own bookings.");
        }
        else
        {
            var host = await _hostRepository.FindOneAsync(new HostByUserIdSpecification(currentUserId))
                       ?? throw new EntityNotFoundException(nameof(Host), currentUserId.ToString());
            if (booking.GuestId != host.Id)
                throw new BookingCancellationException("You can only cancel your own bookings.");
        }

        return booking;
    }
}

public class CancellationMappingProfile : Profile
{
    public CancellationMappingProfile()
    {
        CreateMap<CreateCancellationDto, CancellationTicket>()
            .ForMember(ct => ct.CancellationReasonNote, opt => opt.MapFrom(c => c.Reason))
            .ForMember(ct => ct.Attachments, opt => opt.MapFrom(c => c.Attachments.Select(a => new CancellationTicketAttachment {Url = a})));

        CreateMap<CancellationTicket, GetCancellationDto>()
            .ForMember(dto => dto.IssuerId, opt => opt.MapFrom(ct => ct.CreatedBy))
            .ForMember(dto => dto.Attachments, opt => opt.MapFrom(ct => ct.Attachments.Select(a => a.Url)));
    }
}