using AirCnC.Application.Commons;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Users.Specifications
{
    internal class UsersPagingSpecification: Specification<User>
    {

        public UsersPagingSpecification(PagingParameters pp)
        {
            if (pp.IsDescending)
                ApplyDescending();
            ApplyPaging(pp.PageIndex, pp.PageSize);
        }
    }
}