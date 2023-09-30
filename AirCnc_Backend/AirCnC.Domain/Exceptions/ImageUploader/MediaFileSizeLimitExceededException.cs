namespace AirCnC.Domain.Exceptions.ImageUploader;

public class MediaFileSizeLimitExceededException : Exception
{
    public MediaFileSizeLimitExceededException(int limit) : base($"Media file size limit exceeded. Limit: {limit}MB")
    {
    } 
}