namespace AirCnC.Domain.Exceptions;

public class BadInputException : Exception
{
    public BadInputException(string message) : base(message)
    {
    }
}