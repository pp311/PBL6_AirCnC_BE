using AirCnC.Application.Services.Reviews;
using AirCnC.Application.Services.Reviews.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

/// <summary>
/// Tạo review sẽ ghi đè lên review cũ nếu đã có (nên ko cần api edit)
/// </summary>
[ApiController]
[Route("api/reviews")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    [HttpGet("host/{hostId}")]
    public async Task<IActionResult> GetHostReviews(int hostId, [FromQuery] ReviewQueryParameters rqp)
    {
        var result = await _reviewService.GetHostReviewsAsync(hostId, rqp);
        return Ok(result);
    }
    
    [HttpGet("guest/{guestId}")]
    public async Task<IActionResult> GetGuestReviews(int guestId, [FromQuery] ReviewQueryParameters rqp)
    {
        var result = await _reviewService.GetGuestReviewsAsync(guestId, rqp);
        return Ok(result);
    }
    
    [HttpGet("property/{propertyId}")]
    public async Task<IActionResult> GetPropertyReviews(int propertyId, [FromQuery] ReviewQueryParameters rqp)
    {
        var result = await _reviewService.GetPropertyReviewsAsync(propertyId, rqp);
        return Ok(result);
    }
    
    /// <summary>
    /// Cần author để lấy guest id. Để tiện test nên chưa check xem guest đã từng ở phòng của host này hay ch
    /// </summary>
    [Authorize]
    [HttpPost("host/{hostId}")]
    public async Task<IActionResult> CreateHostReview(int hostId, CreateReviewDto dto)
    {
        var result = await _reviewService.CreateHostReviewAsync(hostId, dto);
        return Ok(result);
    }
    
    /// <summary>
    /// Cần author để lấy hostId của current user. Để tiện test nên chưa check xem host đã từng cho guest này thuê phòng hay ch
    /// </summary>
    [Authorize]
    [HttpPost("guest/{guestId}")]
    public async Task<IActionResult> CreateGuestReview(int guestId, CreateReviewDto dto)
    {
        var result = await _reviewService.CreateGuestReviewAsync(guestId, dto);
        return Ok(result);
    }
    
    /// <summary>
    /// Cần author để lấy guestId của current user. Để tiện test nên chưa check xem guest đã từng thuê phòng hay ch
    /// </summary>
    [Authorize]
    [HttpPost("property/{propertyId}")]
    public async Task<IActionResult> CreatePropertyReview(int propertyId, CreatePropertyReviewDto dto)
    {
        var result = await _reviewService.CreatePropertyReviewAsync(propertyId, dto);
        return Ok(result);
    }
    
    /// <summary>
    /// Chỉ admin hoặc người tạo review mới có quyền xóa
    /// </summary>
    [Authorize]
    [HttpDelete("host/{reviewId}")]
    public async Task<IActionResult> DeleteHostReview(int reviewId)
    {
        await _reviewService.DeleteHostReviewAsync(reviewId);
        return NoContent();
    }
    
    /// <summary>
    /// Chỉ admin hoặc người tạo review mới có quyền xóa
    /// </summary>
    [Authorize]
    [HttpDelete("guest/{reviewId}")]
    public async Task<IActionResult> DeleteGuestReview(int reviewId)
    {
        await _reviewService.DeleteGuestReviewAsync(reviewId);
        return NoContent();
    }
    
    /// <summary>
    /// Chỉ admin hoặc người tạo review mới có quyền xóa
    /// </summary>
    [Authorize]
    [HttpDelete("property/{reviewId}")]
    public async Task<IActionResult> DeletePropertyReview(int reviewId)
    {
        await _reviewService.DeletePropertyReviewAsync(reviewId);
        return NoContent();
    }
}