using AirCnC.Application.Commons;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Application.Commons.Identity;
using AutoMapper;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.CheckIn.Specifications;
using AirCnC.Domain.Exceptions;

namespace AirCnC.Application.Services.CheckIn;
    
public interface ICheckInService
{
    Task CheckInAsync(string Guid);
}    

public class CheckInService : ICheckInService
{

    private readonly IRepository<Booking> _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public CheckInService(IUnitOfWork unitOfWork, IMapper mapper,
        ICurrentUser currentUser, IRepository<Booking> bookingRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
        _bookingRepository = bookingRepository;

    }

    public async Task CheckInAsync(string Guid)
    {
        var booking = await _bookingRepository.FindOneAsync(new BookingByGuidSpecification(Guid));
        await ValidateGuest(booking);
        await ValidateBooking(booking);
        booking.Status = Domain.Enums.BookingStatus.CheckedIn;
        booking.Property.Status=Domain.Enums.PropertyStatus.Unavailable;
        await _unitOfWork.SaveChangesAsync();


    }

    public async Task ValidateBooking(Booking booking)
    {
        if (booking is null)
        {
            throw new Exception("Booking not found");
        }

        if (booking.Status != Domain.Enums.BookingStatus.Confirmed)
        {
            throw new Exception("Booking is not confirmed");
        }
        if (DateTime.Today < booking.CheckInDate|| DateTime.Today>booking.CheckOutDate)
        {
            throw new Exception("Booking is not available");
        }
    }

    public async Task ValidateGuest(Booking booking)
    {
        if (booking.Guest.UserId != int.Parse(_currentUser.Id))
        {
            throw new Exception("You are not the guest of this booking");
        }
    }
}
