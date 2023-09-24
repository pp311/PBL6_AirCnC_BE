using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Specifications.Auth;

public class RefreshTokenSpecification : Specification<RefreshToken>
{
    public RefreshTokenSpecification(string refreshToken)
    {
        AddFilter(rt => rt.Token == refreshToken);
    }
}