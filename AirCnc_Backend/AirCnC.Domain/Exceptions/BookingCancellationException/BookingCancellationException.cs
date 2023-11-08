namespace AirCnC.Domain.Exceptions.BookingCancellationException;

public class BookingCancellationException : BadInputException
{
    public BookingCancellationException(string message) : base(message)
    {
    }
}