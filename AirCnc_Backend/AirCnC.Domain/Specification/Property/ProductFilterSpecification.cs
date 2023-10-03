using AirCnC.Domain.Enums;
using AirCnC.Domain.Enums.Sorting;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;


namespace AirCnC.Domain.Specification.Property;

public class PropertyFilterSpecification : Specification<Domain.Entities.Property>
{
    public PropertyFilterSpecification(string? search, PropertyType? type, PropertySortBy? orderBy, bool isDescending = false)
    {
        AddInclude(p => p.PropertyImages);
        // 1. Search by name, description
        if (!string.IsNullOrWhiteSpace(search))
        {
            AddSearchTerm(search);
            //AddSearchField(nameof(Domain.Entities.Property.Title));
            AddSearchField(nameof(Domain.Entities.Property.Description));
        }
        
        // 2. Filter by type
        if (type != null)
            AddFilter(p => p.Type == type);

        // 3. Order by
        if (orderBy == null) return;
        
        AddOrderByField(orderBy.ToString());
        if (isDescending)
            ApplyDescending();
    } 
}