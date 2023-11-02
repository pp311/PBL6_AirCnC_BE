namespace AirCnC.Domain.Exceptions.CheckIn;

public class InvalidCheckInCodeException : BadInputException
{
    public InvalidCheckInCodeException(Guid code) : base($"Invalid check in code ({code})")
    {
    }
}