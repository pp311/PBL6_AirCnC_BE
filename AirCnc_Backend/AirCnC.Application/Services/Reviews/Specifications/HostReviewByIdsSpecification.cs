using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Reviews.Specifications;

public class HostReviewByIdsSpecification : Specification<HostReview>
{
    public HostReviewByIdsSpecification(int hostId, int guestId)
    {
        AddInclude($"{nameof(Guest)}.{nameof(User)}");
        AddFilter(hr => hr.HostId == hostId && hr.GuestId == guestId);
    } 
}