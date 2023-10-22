using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Reviews.Specifications;

public class PropertyReviewByIdsSpecification : Specification<PropertyReview>
{
    public PropertyReviewByIdsSpecification(int propertyId, int reviewerId)
    {
        AddFilter(pr => pr.PropertyId == propertyId && pr.GuestId == reviewerId);
    } 
}