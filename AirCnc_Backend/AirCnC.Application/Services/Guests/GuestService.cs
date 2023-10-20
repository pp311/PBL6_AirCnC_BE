using AirCnC.Application.Services.Guests.Dtos;
using AirCnC.Application.Services.Guests.Specifications;
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
    private readonly IMapper _mapper;

    public GuestService(IRepository<Guest> guestRepository,
                        IMapper mapper)
    {
        _guestRepository = guestRepository;
        _mapper = mapper;
    }

    public async Task<GetGuestDto> GetGuestAsync(int id)
    {
        var host = await _guestRepository.FindOneAsync(new GuestDetailSpecification(id));
        if (host is null)
            throw new EntityNotFoundException(nameof(Guest), id.ToString());
        return _mapper.Map<GetGuestDto>(host);
    }
}