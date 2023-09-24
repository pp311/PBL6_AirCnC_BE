namespace AirCnC.Domain.Exceptions.Auth;

public class UsernameAlreadyExistException : Exception
{
    public UsernameAlreadyExistException(string username)
        : base($"Username ({username}) was already existed.")
    {
    }
}