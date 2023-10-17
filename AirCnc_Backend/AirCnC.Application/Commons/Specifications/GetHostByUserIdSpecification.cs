using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Commons.Specifications;

public class GetHostByUserIdSpecification : Specification<Host>
{
    public GetHostByUserIdSpecification(int userId)
    {
        AddFilter(h => h.UserId == userId);
    }
}