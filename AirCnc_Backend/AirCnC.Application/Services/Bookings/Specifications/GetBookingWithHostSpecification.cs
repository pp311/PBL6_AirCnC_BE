using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class GetBookingWithHostSpecification : Specification<Booking>
{
    public GetBookingWithHostSpecification(int HostId)
    {
        AddFilter(b=>b.Property.HostId==HostId);
    }
    
}