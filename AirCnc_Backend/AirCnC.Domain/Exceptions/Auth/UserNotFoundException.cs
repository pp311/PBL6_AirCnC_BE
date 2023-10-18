using AirCnC.Domain.Entities;

namespace AirCnC.Domain.Exceptions.Auth;

public class UserNotFoundException : EntityNotFoundException
{
    public UserNotFoundException(string identifier) : base(nameof(User), identifier)
    {
    } 
}