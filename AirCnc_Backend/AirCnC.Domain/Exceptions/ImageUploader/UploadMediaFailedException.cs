namespace AirCnC.Domain.Exceptions.ImageUploader;

public class UploadMediaFailedException : Exception
{
    public UploadMediaFailedException(string message) : base(message)
    {
    } 
}