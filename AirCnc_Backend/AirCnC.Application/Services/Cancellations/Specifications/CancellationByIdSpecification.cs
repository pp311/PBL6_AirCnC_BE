using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;
using Property = Microsoft.EntityFrameworkCore.Metadata.Internal.Property;

namespace AirCnC.Application.Services.Cancellations.Specifications;

public class CancellationByIdSpecification : Specification<CancellationTicket>
{
    public CancellationByIdSpecification(int id)
    {
        AddInclude(x => x.Attachments);
        AddInclude(x => x.ChargePayment!);
        AddInclude(x => x.RefundPayment!);
        AddInclude($"{nameof(Booking)}.{nameof(Property)}.{nameof(Host)}.{nameof(User)}");
        AddInclude($"{nameof(Booking)}.{nameof(Guest)}.{nameof(User)}");
        AddFilter(x => x.Id == id);
    } 
}