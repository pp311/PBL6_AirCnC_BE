using AirCnC.Application.Commons;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Hosts.Specifications;

public class HostsPagingSpecification : Specification<Host>
{
    public HostsPagingSpecification(PagingParameters pp)
    {
        AddInclude(host => host.User);
        ApplyPaging(pp.PageIndex,pp.PageSize);
    } 
}