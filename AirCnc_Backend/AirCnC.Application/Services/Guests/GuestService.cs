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
}

public class GuestService : IGuestService
{
    private readonly IRepository<Guest> _guestRepository;
    private readonly IRepository<GuestReview> _guestReviewRepository;
    private readonly IMapper _mapper;

    public GuestService(IRepository<Guest> guestRepository,
                        IMapper mapper,
                        IRepository<GuestReview> guestReviewRepository)
    {
        _guestRepository = guestRepository;
        _mapper = mapper;
        _guestReviewRepository = guestReviewRepository;
    }

    public async Task<GetGuestDto> GetGuestAsync(int id)
    {
        var host = await _guestRepository.FindOneAsync(new GuestDetailSpecification(id));
        if (host is null)
            throw new EntityNotFoundException(nameof(Guest), id.ToString());
        
        var result = _mapper.Map<GetGuestDto>(host);
        result.NumberOfReviews = await _guestReviewRepository.CountAsync(h => h.GuestId == id);
        result.Rating = await _guestReviewRepository.AverageAsync(new GuestReviewSpecification(id), h => h.Rating);
        return result;
    }
}