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
        AddFilter(p => p.Id == id);
    }
}
