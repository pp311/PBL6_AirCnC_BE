using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Application.Services.Properties.Enums;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Properties.Specifications;

public class PropertyFilterSpecification : Specification<Property>
{
    public PropertyFilterSpecification(PropertyQueryParameters pqp, int hostId = 0)
    {
        AddInclude(p => p.PropertyImages);
        AddInclude(p => p.PropertyReviews);
        AddInclude(p => p.Host.User);
        
        if (hostId > 0)
            AddFilter(p => p.HostId == hostId);
        
        // Search by name, description, city
        if (!string.IsNullOrWhiteSpace(pqp.Search))
        {
            AddSearchTerm(pqp.Search);
            AddSearchField(nameof(Property.Title));
            AddSearchField(nameof(Property.Description));
            AddSearchField(nameof(Property.City));
        }
        
        if (pqp.Type != null && pqp.Type.Any())
            AddFilter(p => pqp.Type.Contains(p.Type));
        
        FilterByPriceRange(pqp);

        FilterByRoomAndBedCount(pqp);

        if (!string.IsNullOrWhiteSpace(pqp.City))
            AddFilter(p => p.City == pqp.City);
        
        FilterByDateRange(pqp);

        FilterByGuestCount(pqp);
        FilterByStatus(pqp);

        // Order by
        if (pqp.OrderBy is not null)
        {
            AddOrderByField(pqp.OrderBy.ToString());
            var orderBy = pqp.OrderBy switch
            {
                PropertySortBy.Rating => $"{nameof(Property.PropertyReviews)}.Average(" +
                                         $"({nameof(PropertyReview.Cleanliness)} + " +
                                         $"{nameof(PropertyReview.Accuracy)} + " +
                                         $"{nameof(PropertyReview.Communication)} + " +
                                         $"{nameof(PropertyReview.CheckIn)} + " +
                                         $"{nameof(PropertyReview.Value)} + " +
                                         $"{nameof(PropertyReview.Location)}) / 6.0)",
                PropertySortBy.NumberOfReviews => $"{nameof(Property.PropertyReviews)}.Count()",
                PropertySortBy.Title => pqp.OrderBy.ToString(),
                PropertySortBy.Description => pqp.OrderBy.ToString(),
                PropertySortBy.PricePerNight => pqp.OrderBy.ToString(),
                _ => nameof(PropertySortBy.Id)
            };
            AddOrderByField(orderBy);
            if (pqp.IsDescending)
                ApplyDescending();
        }
        
        ApplyPaging(pageIndex: pqp.PageIndex, pageSize: pqp.PageSize);
    }

    private void FilterByGuestCount(PropertyQueryParameters pqp)
    {
        // Filter by adult count
        if (pqp.AdultCount > 0)
            AddFilter(p => p.MaxAdultCount >= pqp.AdultCount);

        // Filter by child count
        if (pqp.ChildCount > 0)
            AddFilter(p => p.MaxChildCount >= pqp.ChildCount);
    }

    private void FilterByDateRange(PropertyQueryParameters pqp)
    {
        if (pqp is { CheckInDate: not null, CheckOutDate: not null })
        {
            AddFilter(p => p.Bookings.All(r => r.CheckInDate > pqp.CheckOutDate || r.CheckOutDate < pqp.CheckInDate));        
        }
    }

    private void FilterByRoomAndBedCount(PropertyQueryParameters pqp)
    {
        if (pqp.MinBedroomCount > 0)
            AddFilter(p => p.BedroomCount >= pqp.MinBedroomCount);
        if (pqp.MaxBedroomCount > 0)
            AddFilter(p => p.BedroomCount <= pqp.MaxBedroomCount);

        // Filter by bed count range
        if (pqp.MinBedCount > 0)
            AddFilter(p => p.BedCount >= pqp.MinBedCount);
        if (pqp.MaxBedCount > 0)
            AddFilter(p => p.BedCount <= pqp.MaxBedCount);

        // Filter by bathroom count range
        if (pqp.MinBathroomCount > 0)
            AddFilter(p => p.BathroomCount >= pqp.MinBathroomCount);
        if (pqp.MaxBathroomCount > 0)
            AddFilter(p => p.BathroomCount <= pqp.MaxBathroomCount);
    }

    private void FilterByPriceRange(PropertyQueryParameters pqp)
    {
        if (pqp.MinPrice > 0)
            AddFilter(p => p.PricePerNight >= pqp.MinPrice);
        if (pqp.MaxPrice > 0)
            AddFilter(p => p.PricePerNight <= pqp.MaxPrice);
    }

    private void FilterByStatus(PropertyQueryParameters pqp)
    {
        if (pqp.Status is not null)
            AddFilter(p => p.Status == pqp.Status);
    }
}