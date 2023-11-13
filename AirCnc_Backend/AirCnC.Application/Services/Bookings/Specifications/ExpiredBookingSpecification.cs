using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class ExpiredBookingSpecification : Specification<Booking>
{
    public ExpiredBookingSpecification()
    {
        AddFilter(p => p.Status == BookingStatus.Pending);
        AddFilter(p => p.CreatedAt < DateTime.Now.AddMinutes(-10));
    } 
}