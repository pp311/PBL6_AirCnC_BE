using AirCnC.Application.Services.Reviews.Dtos;
using AirCnC.Application.Services.Reviews.Enums;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Reviews.Specifications;

public class GuestReviewSpecification : Specification<GuestReview>
{
    public GuestReviewSpecification(int guestId, ReviewQueryParameters? rqp = null)
    {
        AddInclude($"{nameof(Host)}.{nameof(User)}");
        AddFilter(gr => gr.GuestId == guestId);
        
        if (rqp == null) return;

        if (rqp.OrderBy != null)
        {
            var orderBy = rqp.OrderBy switch {
                ReviewSortBy.Rating => nameof(GuestReview.Rating),
                ReviewSortBy.CreatedAt => nameof(GuestReview.CreatedAt),
                _ => nameof(GuestReview.CreatedAt)
            };
            
            AddOrderByField(orderBy);

            if (rqp.IsDescending)
                ApplyDescending();
        }
        
        ApplyPaging(rqp.PageIndex, rqp.PageSize); 
    } 
}