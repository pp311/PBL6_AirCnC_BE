using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Cancellations.Specifications;

public class CancellationByIdSpecification : Specification<CancellationTicket>
{
    public CancellationByIdSpecification(int id)
    {
        AddInclude(x => x.Attachments);
        AddFilter(x => x.Id == id);
    } 
}