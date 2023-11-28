using AirCnC.Application.Services.Payments.Dtos;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Payments.Specifications;

public class RefundPaymentSpecification: Specification<RefundPayment>
{
    public RefundPaymentSpecification(RefundPaymentQueryParameter pqp)
    {
        AddInclude(rp=>rp.Guest.User);
        if(pqp.FromDate is not null && pqp.ToDate is not null)
            AddFilter(rp => rp.CreatedAt >= pqp.FromDate && rp.CreatedAt <= pqp.ToDate);
        AddInclude(rp=>rp.Guest);
        if (pqp.UserId is not null)
        {
            AddFilter(x => x.Guest.UserId == pqp.UserId);
        }
        if(pqp.Status is not null)
            AddFilter(x => x.Status == pqp.Status);
        if (pqp.IsDescending)
            ApplyDescending();
        if (pqp.OrderBy is not null)
            AddOrderByField(pqp.OrderBy.ToString());
        else
            AddOrderByField(nameof(ChargePayment.CreatedAt));

        ApplyPaging(pqp.PageIndex,pqp.PageSize);
    }
}