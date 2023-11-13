using AirCnC.Application.Services.Cancellations.Dtos;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Cancellations.Specifications;

public class GetCancellationsSpecification : Specification<CancellationTicket>
{
    public GetCancellationsSpecification(CancellationTicketQueryParameters parameters)
    {
        AddInclude(x => x.Attachments);
        
        if (parameters.Status.HasValue)
            AddFilter(x => x.Status == parameters.Status.Value);    
        
        if (parameters.Type.HasValue)
            AddFilter(x => x.Type == parameters.Type.Value);
        
        if (parameters.IsGuest.HasValue)
            AddFilter(x => x.IsIssuerGuest == parameters.IsGuest.Value);
        
        if (parameters.IssuerId.HasValue)
            AddFilter(x => x.CreatedBy == parameters.IssuerId.Value);

        if (parameters.HostId.HasValue)
        {
            if (parameters.IsGuest.HasValue)
            {
                if (parameters.IsGuest.Value)
                    AddFilter(t => t.TheOtherPartyId == parameters.HostId.Value);
                else
                    AddFilter(t => t.CreatedBy == parameters.HostId.Value);
            }
            else
            {
                AddFilter(t => t.CreatedBy == parameters.HostId.Value || t.TheOtherPartyId == parameters.HostId.Value);
            }
        }
        
        AddOrderByField(parameters.OrderBy?.ToString() ?? nameof(CancellationTicket.Id));
        if (parameters.IsDescending)
            ApplyDescending();
        
        ApplyPaging(parameters.PageIndex, parameters.PageSize);
    } 
}