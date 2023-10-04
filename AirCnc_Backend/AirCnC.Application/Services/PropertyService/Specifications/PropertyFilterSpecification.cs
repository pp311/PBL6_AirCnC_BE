using AirCnC.Application.Services.PropertyService.Enums;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.PropertyService.Specifications;

public class PropertyFilterSpecification : Specification<Property>
{
    public PropertyFilterSpecification(string? search, 
                                       PropertyType? type,
                                       int pageSize,
                                       int pageIndex,
                                       PropertySortBy? orderBy, 
                                       bool isDescending)
    {
        AddInclude(p => p.PropertyImages);
        // 1. Search by name, description
        if (!string.IsNullOrWhiteSpace(search))
        {
            AddSearchTerm(search);
            AddSearchField(nameof(Property.Title));
            AddSearchField(nameof(Property.Description));
        }
        
        // 2. Filter by type
        if (type != null)
            AddFilter(p => p.Type == type);

        // 3. Order by
        if (orderBy is not null)
        {
            AddOrderByField(orderBy.ToString());
            if (isDescending)
                ApplyDescending();
        }
        
        
        // 4. Paging
        ApplyPaging(pageIndex: pageIndex, pageSize: pageSize);
    } 
}