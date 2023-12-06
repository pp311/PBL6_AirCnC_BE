using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Commons.Specifications;

public class HostByUserIdSpecification : Specification<Host>
{
    public HostByUserIdSpecification(int userId)
    {
        AddFilter(h => h.UserId == userId);
        AddInclude(h => h.User);
        AddInclude(h => h.PaymentInfo);
    }
}