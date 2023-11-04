using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AutoMapper;
using AirCnC.Application.Services.CheckIn.Specifications;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.CheckIn;

namespace AirCnC.Application.Services.CheckIn;
    
public interface ICheckInService
{
    Task CheckInAsync(Guid code);
}    

public class CheckInService : ICheckInService
{

    private readonly IRepository<Booking> _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CheckInService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Booking> bookingRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _bookingRepository = bookingRepository;

    }

    public async Task CheckInAsync(Guid code)
    {
        var booking = await _bookingRepository.FindOneAsync(new BookingByGuidSpecification(code.ToString()))
                      ?? throw new InvalidCheckInCodeException(code);
        ValidateBooking(booking);
        booking.Status = BookingStatus.CheckedIn;
        await _unitOfWork.SaveChangesAsync();
    }

    private void ValidateBooking(Booking booking)
    {
        if (booking.Status != BookingStatus.Confirmed)
            throw new BadInputException("Booking is not confirmed");
        
        if (DateTime.Today < booking.CheckInDate|| DateTime.Today > booking.CheckOutDate)
            throw new BadInputException("Booking is not available");
    }
}
