using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Auth.Specifications;

public class RefreshTokenSpecification : Specification<RefreshToken>
{
    public RefreshTokenSpecification(string refreshToken)
    {
        AddFilter(rt => rt.Token == refreshToken);
    }
}