using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Reviews.Specifications;

public class GuestReviewByIdsSpecification : Specification<GuestReview>
{
    public GuestReviewByIdsSpecification(int guestId, int hostId)
    {
        AddFilter(gr => gr.GuestId == guestId && gr.HostId == hostId);
    } 
}