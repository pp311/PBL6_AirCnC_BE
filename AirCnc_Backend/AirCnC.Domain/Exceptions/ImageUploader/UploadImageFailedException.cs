namespace AirCnC.Domain.Exceptions.ImageUploader;

public class UploadImageFailedException : Exception
{
    public UploadImageFailedException(string message) : base(message)
    {
    } 
}