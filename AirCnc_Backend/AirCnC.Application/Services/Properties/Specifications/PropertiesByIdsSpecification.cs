using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Properties.Specifications;

public class PropertiesByIdsSpecification : Specification<Property>
{
    public PropertiesByIdsSpecification(List<int> ids, int pageIndex, int pageSize)
    {
        AddInclude(p => p.Host.User);
        AddInclude(p => p.PropertyImages);
        AddInclude(p => p.PropertyUtilities);
        AddInclude(p => p.PropertyReviews);
        AddInclude(p => p.Wishlists);
        AddFilter(p => ids.Contains(p.Id));
        ApplyPaging(pageIndex: pageIndex, pageSize: pageSize);
    } 
}