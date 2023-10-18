using AirCnC.Domain.Entities;

namespace AirCnC.Domain.Exceptions.Auth;

public class UsernameAlreadyExistException : EntityAlreadyExistedException
{
    public UsernameAlreadyExistException(string username)
        : base(nameof(User), username)
    {
    }
}