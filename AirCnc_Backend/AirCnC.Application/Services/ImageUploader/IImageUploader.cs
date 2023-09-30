namespace AirCnC.Application.Services.ImageUploader;

public interface IImageUploader
{
    public Task<string> UploadAvatarImageAsync(string fileName, Stream stream);
    public Task<string> UploadPropertyImageAsync(string fileName, Stream stream);
    public Task<string> UploadMediaFileAsync(string fileName, Stream stream);
}