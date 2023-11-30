using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class MeetCheckOutDateBookingSpecification : Specification<Booking>
{
    public MeetCheckOutDateBookingSpecification()
    {
        AddFilter(b => b.CheckOutDate.Date == DateTime.Now.Date);
    }
}