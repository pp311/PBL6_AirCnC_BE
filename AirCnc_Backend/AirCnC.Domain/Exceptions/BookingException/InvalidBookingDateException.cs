namespace AirCnC.Domain.Exceptions.BookingException;

public class InvalidBookingDateException : BadInputException
{
    public InvalidBookingDateException(string message) : base(message)
    {
    }
}