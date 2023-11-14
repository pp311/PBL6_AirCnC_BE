using AirCnC.Application.Services.HostPayments.Dtos;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.HostPayments.Specifications;

public class GetHostPaymentsSpecification:Specification<HostPayment>
{
    public GetHostPaymentsSpecification(HostPaymentQueryParameters hqp,int? hostId=null)
    {
        AddInclude(hp=>hp.PaymentInfo.Host);
        if(hqp.Status is not null)
            AddFilter(h => h.Status == hqp.Status);
        if (hqp.IsDescending)
            ApplyDescending();
        if (hostId is not null)
        {
            AddFilter(h=>h.PaymentInfo.HostId==hostId);
        }
        ApplyPaging(hqp.PageIndex, hqp.PageSize);
    }
}