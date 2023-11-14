using AirCnC.Application.Services.HostPayments.Dtos;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.HostPayments.Specifications;

public class GetHostPaymentSpecification : Specification<HostPayment>
{
    public GetHostPaymentSpecification(int HostPaymentInfo)
    {
        AddInclude(hp=>hp.PaymentInfo.Host);
        AddFilter(hp=>hp.Id==HostPaymentInfo);
    }
}