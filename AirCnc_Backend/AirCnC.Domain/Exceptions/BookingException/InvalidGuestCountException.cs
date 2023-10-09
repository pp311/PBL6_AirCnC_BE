namespace AirCnC.Domain.Exceptions.BookingException;

public class InvalidGuestCountException : BadInputException
{
    public InvalidGuestCountException(string message) : base(message)
    {
    }
}