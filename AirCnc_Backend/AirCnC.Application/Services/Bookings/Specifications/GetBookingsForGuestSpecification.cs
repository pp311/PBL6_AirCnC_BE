using AirCnC.Application.Services.Bookings.Dtos;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class GetBookingsForGuestSpecification : Specification<Booking>
{
    public GetBookingsForGuestSpecification(int guestId, BookingQueryParameters bqp)
    {
        AddInclude(b => b.Property);
        AddInclude($"{nameof(Property)}.{nameof(Property.Host)}.{nameof(Property.Host.User)}");

        AddFilter(b => b.GuestId == guestId);
        
        if (bqp.Status is not null)
            AddFilter(b => b.Status == bqp.Status);
        
        if (bqp is { Search: not null })
        {
            AddSearchTerm(bqp.Search);
            AddSearchField("Property.Host.User.FullName");
            AddSearchField("Property.Host.User.Email");
            AddSearchField("Property.Host.User.PhoneNumber");
            AddSearchField("Property.Title");
        }
        
        AddOrderByField(bqp.OrderBy?.ToString() ?? nameof(Booking.CheckInDate));
        if (bqp.IsDescending)
            ApplyDescending();
        
        ApplyPaging(bqp.PageIndex, bqp.PageSize);
    }
}