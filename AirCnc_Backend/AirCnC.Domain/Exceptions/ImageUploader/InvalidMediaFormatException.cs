namespace AirCnC.Domain.Exceptions.ImageUploader;

public class InvalidMediaFormatException : Exception
{
    public InvalidMediaFormatException() : base("Invalid media format")
    {
    }
}