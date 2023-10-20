using AirCnC.Application.Services.Bookings.Dtos;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Bookings.Specifications;

public class GetBookingsForHostSpecification : Specification<Booking>
{
    public GetBookingsForHostSpecification(int hostId, BookingQueryParameters bqp)
    {
        AddInclude(b => b.Property);
        AddInclude($"{nameof(Guest)}.{nameof(Guest.User)}");

        AddFilter(b => b.Property.HostId == hostId);
        
        if (bqp.Status is not null)
            AddFilter(b => b.Status == bqp.Status);
        
        if (bqp is { Search: not null })
        {
            AddSearchTerm(bqp.Search);
            AddSearchField("Guest.User.FullName");
            AddSearchField("Guest.User.Email");
            AddSearchField("Guest.User.PhoneNumber");
            AddSearchField("Property.Title");
        }
        
        AddOrderByField(bqp.OrderBy?.ToString() ?? nameof(Booking.CheckInDate));
        if (bqp.IsDescending)
            ApplyDescending();
        
        ApplyPaging(bqp.PageIndex, bqp.PageSize);
    }
}