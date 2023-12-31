using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class ActiveBookingBetweenDatesSpecification : Specification<Booking>
{
    public ActiveBookingBetweenDatesSpecification(int propertyId, DateTime fromDate, DateTime toDate)
    {
        // Lay nhung booking dang active trong khoang tu fromDate den toDate
        // Ngay Checkout cua booking nay co the la ngay Checkin cua booking khac 
        AddFilter(p => p.PropertyId == propertyId);
        
        AddFilter(p => p.Status != BookingStatus.Rejected && p.Status != BookingStatus.CancelledAfterCheckIn
                                                          && p.Status != BookingStatus.Completed
                                                          && p.Status != BookingStatus.CancelledBeforeCheckIn);

        AddFilter(p => (p.CheckOutDate.Date <= toDate.Date && p.CheckOutDate.Date > fromDate.Date)
                || (p.CheckInDate.Date <= toDate.Date && p.CheckInDate.Date >= fromDate.Date));
    }
}
