using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class IsGuestStayedSpecification : Specification<Booking>
{
    public IsGuestStayedSpecification(int propertyId, int guestId)
    {
        AddFilter(b => b.GuestId == guestId);
        AddFilter(b => b.PropertyId == propertyId);
        AddFilter(b => b.Status == BookingStatus.Completed || b.Status == BookingStatus.CancelledAfterCheckIn);
    } 
}