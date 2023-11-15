using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Application.Services.Guests.Dtos;
using AirCnC.Application.Services.Guests.Specifications;
using AirCnC.Application.Services.Reviews.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AutoMapper;

namespace AirCnC.Application.Services.Guests;

public interface IGuestService
{
    Task<GetGuestDto> GetGuestAsync(int id);
    Task<bool> CheckGuestIsStayedAsync(int guestId);
}

public class GuestService : IGuestService
{
    private readonly IRepository<Guest> _guestRepository;
    private readonly IRepository<Host> _hostRepository;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<GuestReview> _guestReviewRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IMapper _mapper;

    public GuestService(IRepository<Guest> guestRepository,
                        IMapper mapper,
                        IRepository<GuestReview> guestReviewRepository,
                        ICurrentUser currentUser,
                        IRepository<Host> hostRepository,
                        IRepository<Booking> bookingRepository)
    {
        _guestRepository = guestRepository;
        _mapper = mapper;
        _guestReviewRepository = guestReviewRepository;
        _currentUser = currentUser;
        _hostRepository = hostRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<GetGuestDto> GetGuestAsync(int id)
    {
        var host = await _guestRepository.FindOneAsync(new GuestDetailSpecification(id));
        if (host is null)
            throw new EntityNotFoundException(nameof(Guest), id.ToString());
        
        var result = _mapper.Map<GetGuestDto>(host);
        result.NumberOfReviews = await _guestReviewRepository.CountAsync(h => h.GuestId == id);
        if (result.NumberOfReviews > 0)
            result.Rating = await _guestReviewRepository
                                .AverageAsync(new GuestReviewSpecification(id), h => h.Rating);
        return result;
    }

    public async Task<bool> CheckGuestIsStayedAsync(int guestId)
    {
        var currentUserId = int.TryParse(_currentUser.Id, out var id) ? id : 0;
        if (currentUserId == 0) return false;
        
        var host = await _hostRepository.FindOneAsync(new HostByUserIdSpecification(currentUserId));
        if (host is null) return false;

        var spec = new IsGuestStayedInHostPropertySpecification(host.Id, guestId);
        return await _bookingRepository.AnyAsync(spec);
    }
}