using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Commons.Specifications;

public class GuestByUserIdSpecification : Specification<Guest>
{
    public GuestByUserIdSpecification(int userId)
    {
        AddFilter(g => g.UserId == userId);
    } 
}