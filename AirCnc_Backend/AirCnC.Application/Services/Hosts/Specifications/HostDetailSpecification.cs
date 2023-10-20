using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Hosts.Specifications;

public class HostDetailSpecification : Specification<Host>
{
    public HostDetailSpecification(int id)
    {
        AddInclude(host => host.User);
        AddFilter(host => host.Id == id);
    } 
}