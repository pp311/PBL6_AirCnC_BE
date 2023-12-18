using AirCnC.Application.Commons.Identity;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AutoMapper;
using AirCnC.Application.Services.CheckIn.Specifications;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.CheckIn;
using AirCnC.Application.Services.Bookings.Dtos;

namespace AirCnC.Application.Services.CheckIn;
    
public interface ICheckInService
{
    Task<GetBookingForHostDto> CheckInAsync(Guid guid);
}    

public class CheckInService : ICheckInService
{

    private readonly IRepository<Booking> _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public CheckInService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Booking> bookingRepository, ICurrentUser currentUser)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _bookingRepository = bookingRepository;
        _currentUser = currentUser;

    }

    public async Task<GetBookingForHostDto> CheckInAsync(Guid guid)
    {
        var booking = await _bookingRepository.FindOneAsync(new BookingByGuidSpecification(guid.ToString()))
                      ?? throw new InvalidCheckInCodeException(guid);
        ValidateBooking(booking);
        ValidateHost(booking);
        booking.Status = BookingStatus.CheckedIn;
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GetBookingForHostDto>(booking);
    }

    private void ValidateBooking(Booking booking)
    {
        if (booking.Status != BookingStatus.Confirmed)
            throw new BadInputException("Booking is not confirmed");
        
        if (DateTime.Today.Date < booking.CheckInDate.Date|| DateTime.Today.Date > booking.CheckOutDate.Date)
            throw new BadInputException("Booking is not available");
    }

    private void ValidateHost(Booking booking)
    {
        if (booking.Property.Host.UserId.ToString() != _currentUser.Id)
            throw new ForbiddenAccessException();
    }
}
