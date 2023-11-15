using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class IsGuestStayedInHostPropertySpecification : Specification<Booking>
{
    public IsGuestStayedInHostPropertySpecification(int hostId, int guestId)
    {
        AddFilter(b => b.GuestId == guestId);
        AddFilter(b => b.Property.HostId == hostId);
        AddFilter(b => b.Status == BookingStatus.Completed || b.Status == BookingStatus.CancelledAfterCheckIn);
    } 
}