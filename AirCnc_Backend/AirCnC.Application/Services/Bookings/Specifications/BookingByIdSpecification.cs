using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class BookingByIdSpecification : Specification<Booking>
{
    public BookingByIdSpecification(int id)
    {
        AddInclude($"{nameof(Property)}.{nameof(Host)}.{nameof(User)}");
        AddInclude($"{nameof(Guest)}.{nameof(User)}");
        AddFilter(b => b.Id == id);
    } 
}