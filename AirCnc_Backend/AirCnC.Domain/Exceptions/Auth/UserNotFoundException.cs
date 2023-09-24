namespace AirCnC.Domain.Exceptions.Auth;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string identifier)
        : base($"User ({identifier}) was not found.")
    {
    } 
}