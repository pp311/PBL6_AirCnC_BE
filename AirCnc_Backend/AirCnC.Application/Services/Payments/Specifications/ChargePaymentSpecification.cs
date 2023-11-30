using AirCnC.Application.Services.Payments.Dtos;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Payments.Specifications;

public class ChargePaymentSpecification : Specification<ChargePayment>
{
    public ChargePaymentSpecification(ChargePaymentQueryParameter pqp)
    {
        AddInclude(cp => cp.Host.User);

        if (pqp.FromDate is not null && pqp.ToDate is not null)
            AddFilter(cp => cp.CreatedAt >= pqp.FromDate && cp.CreatedAt <= pqp.ToDate);
        AddInclude(cp=>cp.Host);
        if (pqp.UserId is not null)
        {
            AddFilter(x => x.Host.UserId == pqp.UserId);
        }
        if(pqp.Status is not null)
            AddFilter(x => x.Status == pqp.Status);

        if(pqp.IsDescending)
            ApplyDescending();

        if (pqp.OrderBy is not null)
            AddOrderByField(pqp.OrderBy.ToString());
        else
            AddOrderByField(nameof(ChargePayment.CreatedAt));

        ApplyPaging(pqp.PageIndex,pqp.PageSize);
    }
}
