using AirCnC.Application.Services.ImageUploader.Dtos;

namespace AirCnC.Application.Services.ImageUploader;

public interface IImageUploader
{
    public Task<MediaUrlDto> UploadAvatarImageAsync(string fileName, Stream stream);
    public Task<MediaUrlDto> UploadPropertyImageAsync(string fileName, Stream stream);
    public Task<MediaUrlDto> UploadMediaFileAsync(string fileName, Stream stream);

    Task<MediaUrlDto> UploadAvatarImageV2Async(string fileFileName, Stream openReadStream);
}