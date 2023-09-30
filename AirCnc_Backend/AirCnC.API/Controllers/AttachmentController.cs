using AirCnC.Application.Services.ImageUploader;
using AirCnC.Domain.Exceptions.ImageUploader;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]
[Route("api/attachments")]
public class AttachmentController : ControllerBase
{
    private readonly IImageUploader _imageUploader;

    public AttachmentController(IImageUploader imageUploader)
    {
        _imageUploader = imageUploader;
    }
    
    [HttpPost("avatar")]
    public async Task<IActionResult> UploadAvatarImage([FromForm] IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty");
        
        ValidateImage(file);

        var url = await _imageUploader.UploadAvatarImageAsync(file.FileName, file.OpenReadStream());
        return Ok(url);
    }
    
    [HttpPost("property")]
    public async Task<IActionResult> UploadPropertyImage([FromForm] IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty");
        
        ValidateImage(file);

        var url = await _imageUploader.UploadPropertyImageAsync(file.FileName, file.OpenReadStream());
        return Ok(url);
    }
    
    [HttpPost("media")]
    public async Task<IActionResult> UploadMediaFile([FromForm] IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty");
        
        ValidateMedia(file);

        var url = await _imageUploader.UploadMediaFileAsync(file.FileName, file.OpenReadStream());
        return Ok(url);
    }
    
    private static void ValidateImage(IFormFile file)
    {
        var ext = Path.GetExtension(file.FileName);
        if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
            throw new InvalidMediaFormatException();

        if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            throw new InvalidMediaFormatException();

        if (file.Length > 1024 * 1024 * 5)
            throw new MediaFileSizeLimitExceededException(5);
    }
    
    // for both image and video
    private static void ValidateMedia(IFormFile file)
    {
        var ext = Path.GetExtension(file.FileName);
        if (ext != ".jpg" && ext != ".png" && ext != ".jpeg" && ext != ".mp4")
            throw new InvalidMediaFormatException();
        
        if (file.ContentType != "image/jpeg" && file.ContentType != "image/png" && file.ContentType != "video/mp4")
            throw new InvalidMediaFormatException();

        if (file.Length > 1024 * 1024 * 10)
            throw new MediaFileSizeLimitExceededException(10);
    }
    
}