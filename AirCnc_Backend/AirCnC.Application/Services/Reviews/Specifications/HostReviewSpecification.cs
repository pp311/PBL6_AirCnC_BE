using AirCnC.Application.Services.Reviews.Dtos;
using AirCnC.Application.Services.Reviews.Enums;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Reviews.Specifications;

public class HostReviewSpecification : Specification<HostReview>
{
    public HostReviewSpecification(int hostId, ReviewQueryParameters? rqp = null)
    {
        AddInclude($"{nameof(Guest)}.{nameof(User)}");
        AddFilter(hr => hr.HostId == hostId);
        
        if (rqp == null) return;
        
        if (rqp.OrderBy != null)
        {
            var orderBy = rqp.OrderBy switch {
                ReviewSortBy.Rating => nameof(HostReview.Rating),
                ReviewSortBy.CreatedAt => nameof(HostReview.CreatedAt),
                _ => nameof(HostReview.CreatedAt)
            };
            
            AddOrderByField(orderBy);

            if (rqp.IsDescending)
                ApplyDescending();
        } 
        
        ApplyPaging(rqp.PageIndex, rqp.PageSize);
    }
}