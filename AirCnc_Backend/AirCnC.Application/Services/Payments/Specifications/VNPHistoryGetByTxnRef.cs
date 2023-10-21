using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Payments.Specifications;

public class VNPHistoryGetByTxnRef : Specification<VNPHistory>
{
    public VNPHistoryGetByTxnRef(long TxnRef)
    {
        AddInclude(p=>p.BookingPayment);
        AddFilter(p => p.vnp_TxnRef == TxnRef);
    }
}
