using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.BookingService.Specifications;

public class ActiveBookingBetweenDatesSpecification : Specification<Booking>
{
    public ActiveBookingBetweenDatesSpecification(DateTime fromDate, DateTime toDate)
    {
        // Lay nhung booking dang active trong khoang tu fromDate den toDate
        // Ngay Checkout cua booking nay co the la ngay Checkin cua booking khac 
        AddFilter(p => p.CheckOutDate.Date > fromDate.Date && p.CheckInDate.Date < toDate.Date);
    } 
}