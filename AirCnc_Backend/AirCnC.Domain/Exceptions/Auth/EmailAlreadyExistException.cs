namespace AirCnC.Domain.Exceptions.Auth;

public class EmailAlreadyExistException : Exception
{
    public EmailAlreadyExistException(string email)
        : base($"Email ({email}) was already existed.")
    {
    }
}