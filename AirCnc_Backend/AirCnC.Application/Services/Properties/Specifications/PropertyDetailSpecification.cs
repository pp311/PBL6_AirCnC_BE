using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Properties.Specifications;

public class PropertyDetailSpecification : Specification<Property>
{
    public PropertyDetailSpecification(int id)
    {
        AddInclude(p => p.Host.User);
        AddInclude(p => p.PropertyImages);
        AddInclude(p => p.PropertyUtilities);
        AddInclude(p => p.PropertyReviews);
        AddInclude(p => p.Wishlists);
        AddFilter(p => p.Id == id);
    }
}
