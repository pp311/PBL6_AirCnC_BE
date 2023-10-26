using AirCnC.Application.Commons;
using AirCnC.Application.Services.Wishlists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;
    
[Authorize]
[ApiController]
[Route("api/wishlists")]
public class WishlistController : ControllerBase
{
    private readonly IWishlistService _wishlistService;

    public WishlistController(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPropertyList([FromQuery] PagingParameters pqp)
    {
        var result = await _wishlistService.GetListAsync(pqp);
        return Ok(result);
    }

    [HttpPost("properties/{propertyId:int}")]
    public async Task<IActionResult> AddWishlistItem(int propertyId)
    {
        await _wishlistService.AddWishlistAsync(propertyId);
        return Ok();
    }

    [HttpDelete("properties/{propertyId:int}")]
    public async Task<IActionResult> DeleteWishlistItem(int propertyId)
    {
        await _wishlistService.RemoveWishlistItemByIdAsync(propertyId);
        return Ok();
    }
}
