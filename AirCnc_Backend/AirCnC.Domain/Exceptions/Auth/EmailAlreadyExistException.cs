namespace AirCnC.Domain.Exceptions.Auth;

public class EmailAlreadyExistException : EntityAlreadyExistedException
{
    public EmailAlreadyExistException(string email) : base("Email", email)
    {
    }
}