using AirCnC.Application.Commons;
using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Application.Services.Wishlists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirCnC.API.Controllers
{
    [Route("api/Wishlists")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }
        // GET: api/<WishlistController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPropertyList([FromQuery] PagingParameters pqp)
        {
            var result = await _wishlistService.GetListAsync(pqp);
            return Ok(result);
        }

        // POST api/<WishlistController>
        [HttpPost("{propertyId}")]
        [Authorize]
        public async Task<IActionResult> AddWishlistItem(int propertyId)
        {
            await _wishlistService.AddWishlistAsync(propertyId);
            return Ok();
        }


        // DELETE api/<WishlistController>/5
        [HttpDelete("{propertyId}")]
        [Authorize]
        public async Task<IActionResult> DeleteWishlistItem(int propertyId)
        {
            await _wishlistService.RemoveWishlistItemByIdAsync(propertyId);
            return Ok();
        }
    }
}
