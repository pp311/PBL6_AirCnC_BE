using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.HostPayments.Specifications;

public class GetHostPaymentSpecification : Specification<HostPayment>
{
    public GetHostPaymentSpecification(int hostPaymentInfo)
    {
        AddInclude(hp => hp.PaymentInfo.Host);
        AddFilter(hp => hp.Id == hostPaymentInfo);
    }
}