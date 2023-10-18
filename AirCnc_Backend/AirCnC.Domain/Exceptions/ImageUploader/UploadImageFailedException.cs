namespace AirCnC.Domain.Exceptions.ImageUploader;

public class UploadImageFailedException : BadInputException
{
    public UploadImageFailedException(string message) : base(message)
    {
    } 
}