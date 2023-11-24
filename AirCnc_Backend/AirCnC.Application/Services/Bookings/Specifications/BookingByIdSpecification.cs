using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class BookingByIdSpecification : Specification<Booking>
{
    public BookingByIdSpecification(int id)
    {
        AddInclude($"{nameof(Property)}.{nameof(Host)}.{nameof(User)}");
        AddInclude($"{nameof(Guest)}.{nameof(User)}");
        AddInclude(b=>b.BookingPayment);
        AddInclude(b=>b.BookingPayment.VnpHistories);
        AddFilter(b => b.Id == id);
    } 
}