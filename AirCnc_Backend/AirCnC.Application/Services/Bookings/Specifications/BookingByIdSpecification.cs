using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class BookingByIdSpecification : Specification<Booking>
{
    public BookingByIdSpecification(int id)
    {
        // AddInclude($"{nameof(Property)}.{nameof(Host)}");
        AddInclude(b => b.Property);
        AddInclude(b => b.Guest);
        AddFilter(b => b.Id == id);
    } 
}