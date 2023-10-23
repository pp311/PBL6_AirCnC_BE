using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Payments.Specifications;

public class BookingPaymentByBookingIdSpecification : Specification<BookingPayment>
{
    public BookingPaymentByBookingIdSpecification(int bookingId)
    {
        AddFilter(x => x.BookingId == bookingId);
    } 
}