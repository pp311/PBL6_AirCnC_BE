using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.BookingService.Specifications;

public class GetPropertyWithHostSpecification : Specification<Property>
{
    public GetPropertyWithHostSpecification(int propertyId)
    {
        AddInclude(p => p.Host);
        AddFilter(p => p.Id == propertyId);
    }
    
}