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
        var today = DateTime.Now;
        
        if (booking.CheckInDate.Date >= today || booking.Status is BookingStatus.CheckedIn)
            cancellationTicket.Type = CancellationTicketType.CancelledAfterCheckIn;
        else if (booking.CheckInDate.Date <= today.Date && booking.CheckInDate.Date >= today.AddDays(-1))
            cancellationTicket.Type = CancellationTicketType.CancelledBeforeCheckIn;
        else if (booking.CheckInDate.Date <= today.Date.AddDays(-1) && booking.CheckInDate.Date >= today.AddDays(-3))
            cancellationTicket.Type = CancellationTicketType.CancelledBefore1Days;
        else
            cancellationTicket.Type = CancellationTicketType.CancelledBefore3Days;

        booking.Status = booking.Status == BookingStatus.CheckedIn 
                             ? BookingStatus.CancelledAfterCheckIn 
                             : BookingStatus.CancelledBeforeCheckIn;
        
        // Todo: Calculate refund amount and charge amount
        if (cancellationTicket.IsIssuerGuest)
        {
            if (booking.CancellationPolicyType == CancellationPolicyType.Flexible)
            {
                if (cancellationTicket.Type == CancellationTicketType.CancelledAfterCheckIn)
                {
                    // Neu cancel sau checkin: tinh tien = so dem da o + 1 va co clean fee
                    var stayedFee = booking.PricePerNight * ((DateTime.Now.Date - booking.CheckInDate.Date).Days + 1);
                    cancellationTicket.RefundAmount = booking.TotalPrice - (stayedFee + booking.CleaningFee);
                }
                else if (cancellationTicket.Type == CancellationTicketType.CancelledBeforeCheckIn)
                {
                    // Neu cancel trong vong 24h truoc check-in: tinh tien = 1 dem
                    cancellationTicket.RefundAmount = booking.TotalPrice - booking.PricePerNight;
                }
                else
                    cancellationTicket.RefundAmount = booking.TotalPrice;
            }
            else
            {
                if (cancellationTicket.Type == CancellationTicketType.CancelledAfterCheckIn)
                {
                    // Neu cancel sau checkin: tinh tien = so dem da o + 1 va 50% cac dem chua o va co clean fee
                    var stayedDays = (DateTime.Now.Date - booking.CheckInDate.Date).Days;
                    var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                    var stayedFee = booking.PricePerNight * (stayedDays + 1);
                    var notStayedFee = booking.PricePerNight * (bookingDays - stayedDays) * 0.5;
                    cancellationTicket.RefundAmount = booking.TotalPrice - (stayedFee + notStayedFee + booking.CleaningFee);
                }
                else if (cancellationTicket.Type == CancellationTicketType.CancelledBeforeCheckIn 
                         || cancellationTicket.Type == CancellationTicketType.CancelledBefore1Days)
                {
                    // Neu cancel trong vong 24h truoc check-in: tinh tien = 1 dem
                    var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                    var notStayedFee = booking.PricePerNight * bookingDays * 0.5;
                    cancellationTicket.RefundAmount = booking.TotalPrice - notStayedFee;
                }
                else
                    cancellationTicket.RefundAmount = booking.TotalPrice;
            }
        }
        else
        {
            cancellationTicket.RefundAmount = booking.TotalPrice;
            if (cancellationTicket.Type == CancellationTicketType.CancelledAfterCheckIn)
            {
                // Neu cancel sau checkin: phat tien = 50% cac dem chua o
                var stayedDays = (DateTime.Now.Date - booking.CheckInDate.Date).Days;
                var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                var notStayedFee = booking.PricePerNight * (bookingDays - stayedDays) * 0.5;
                cancellationTicket.ChargeAmount = notStayedFee;
            }
            else if (cancellationTicket.Type == CancellationTicketType.CancelledBeforeCheckIn) 
            {
                // Neu cancel trong vong 24h truoc check-in: 50%  cac dem chua o
                var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                var notStayedFee = booking.PricePerNight * bookingDays * 0.5;
                cancellationTicket.ChargeAmount = notStayedFee;
            }
            else if (cancellationTicket.Type == CancellationTicketType.CancelledBefore1Days)
            {
                // Trong vong 3 ngay: 25%
                var bookingDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
                var notStayedFee = booking.PricePerNight * bookingDays * 0.25;
                cancellationTicket.ChargeAmount = notStayedFee;
            }
            else
            {
                // Truoc 3 ngay: 0%
                cancellationTicket.ChargeAmount = 0;
            }
        }
        
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

        cancellationTicket.RefundAmount = dto.RefundAmount;
        cancellationTicket.ChargeAmount = dto.ChargeAmount;
        
        //Todo: create refund payment & charge payment
        
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
        
        if ((booking.CheckOutDate.Date - DateTime.Now.Date).Days == 0)
            throw new BookingCancellationException("You can only cancel bookings at least 1 day before check-out date");      

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