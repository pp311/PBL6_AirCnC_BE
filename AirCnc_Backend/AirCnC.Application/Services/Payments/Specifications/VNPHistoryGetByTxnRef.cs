using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Payments.Specifications;

public class VnpHistoryGetByTxnRef : Specification<VnpHistory>
{
    public VnpHistoryGetByTxnRef(long txnRef)
    {
        AddInclude(p=>p.BookingPayment);
        AddFilter(p => p.vnp_TxnRef == txnRef);
    }
}
