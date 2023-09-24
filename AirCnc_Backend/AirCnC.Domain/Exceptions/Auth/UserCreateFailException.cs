namespace AirCnC.Domain.Exceptions.Auth;

public class UserCreateFailException : Exception
{
    public UserCreateFailException(string message) : base(message)
    {
    }
}