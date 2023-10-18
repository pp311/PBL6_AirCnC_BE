namespace AirCnC.Domain.Exceptions.ImageUploader;

public class InvalidMediaFormatException : BadInputException
{
    public InvalidMediaFormatException() : base("Invalid media format")
    {
    }
}