using AirCnC.Application.Commons;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Users.Specifications
{
    internal class UsersPagingSpecification: Specification<User>
    {

        public UsersPagingSpecification(PagingParameters pp)
        {
            ApplyPaging(pp.PageIndex,pp.PageSize);
        }
    }
}