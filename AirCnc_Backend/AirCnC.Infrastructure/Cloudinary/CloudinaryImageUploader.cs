using AirCnC.Application.Services.ImageUploader;
using AirCnC.Application.Services.ImageUploader.Dtos;
using AirCnC.Domain.Exceptions.ImageUploader;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Logging;

namespace AirCnC.Infrastructure.Cloudinary;

public class CloudinaryImageUploader : IImageUploader
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;
    private readonly ILogger<CloudinaryImageUploader> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public CloudinaryImageUploader(CloudinaryDotNet.Cloudinary cloudinary,
                                   ILogger<CloudinaryImageUploader> logger,
                                   IHttpClientFactory httpClientFactory)
    {
        _cloudinary = cloudinary;
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<MediaUrlDto> UploadAvatarImageAsync(string fileName, Stream stream)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription($"{Guid.NewGuid()}-{fileName}", stream),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = false,
            Folder = "avatar",
            Transformation = new Transformation().Width(250).Height(250).Crop("fill")
        };

        var result = await _cloudinary.UploadAsync(uploadParams);
        if (result.Error == null)
            return new MediaUrlDto { Url = result.Url.AbsoluteUri };

        _logger.LogError("Upload file {name} to cloudinary failed: {error}", fileName, result.Error.Message);
        throw new UploadImageFailedException(result.Error!.Message);
    }

    public async Task<MediaUrlDto> UploadPropertyImageAsync(string fileName, Stream stream)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription($"{Guid.NewGuid()}-{fileName}", stream),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = false,
            Folder = "property",
        };

        var result = await _cloudinary.UploadAsync(uploadParams);
        if (result.Error == null)
            return new MediaUrlDto { Url = result.Url.AbsoluteUri };

        _logger.LogError("Upload file {name} to cloudinary failed: {error}", fileName, result.Error.Message);
        throw new UploadImageFailedException(result.Error!.Message);
    }

    public async Task<MediaUrlDto> UploadMediaFileAsync(string fileName, Stream stream)
    {
        var uploadParams = new RawUploadParams
        {
            File = new FileDescription($"{Guid.NewGuid()}-{fileName}", stream),
            UseFilename = true,
            UniqueFilename = false,
            Overwrite = false,
            Folder = "media",
        };

        var result = await _cloudinary.UploadAsync(uploadParams);
        if (result.Error == null)
            return new MediaUrlDto { Url = result.Url.AbsoluteUri };

        _logger.LogError("Upload file {name} to cloudinary failed: {error}", fileName, result.Error.Message);
        throw new UploadMediaFailedException(result.Error!.Message);
    }

    public async Task<MediaUrlDto> UploadAvatarImageV2Async(string fileFileName, Stream openReadStream)
    {
        var httpClient = _httpClientFactory.CreateClient();
        
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(openReadStream), "media", fileFileName);
        var response = await httpClient.PostAsync("http://192.168.3.115:8484/image", content);
        
        if (response.IsSuccessStatusCode)
        {
            var relativePath = response.Headers.GetValues("Location").FirstOrDefault();
            var url = $"http://thumbor.whitemage.tech{relativePath}";
            return new MediaUrlDto { Url = url };
        }

        var result = await response.Content.ReadAsStringAsync();
        _logger.LogError("Upload file {name} failed: {error}", fileFileName, result);
        throw new UploadImageFailedException(result);
    }
}