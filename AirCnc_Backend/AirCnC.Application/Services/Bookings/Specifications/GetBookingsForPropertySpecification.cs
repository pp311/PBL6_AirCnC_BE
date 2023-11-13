using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class GetBookingsForPropertySpecification : Specification<Booking>
{
    public GetBookingsForPropertySpecification(int propertyId, DateTime fromDate, DateTime toDate)
    {
        AddFilter(p => p.PropertyId == propertyId);

        // Lay nhung booking dang active trong khoang tu fromDate den toDate
        AddFilter(p => p.CheckOutDate.Date >= fromDate.Date && p.CheckInDate.Date <= toDate.Date);
    } 
}