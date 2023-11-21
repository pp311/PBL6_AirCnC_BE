using AirCnC.Application.Services.Guests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]
[Route("api/guests")]
public class GuestController : ControllerBase
{
    private readonly IGuestService _guestService;

    public GuestController(IGuestService guestService)
    {
        _guestService = guestService;
    }

    [HttpGet("{guestId:int}")]
    public async Task<IActionResult> GetGuestById(int guestId)
    {
        var result = await _guestService.GetGuestAsync(guestId);
        return Ok(result);
    }
    
    /// <summary>
    /// Check xem guest đã từng ở tại property của host hay chưa (nếu mình không phải host hoặc chưa login thì luôn false)
    /// </summary>
    [HttpGet("{guestId:int}/is-stayed")]
    [Authorize]
    public async Task<IActionResult> CheckGuestIsStayed(int guestId)
    {
        var result = await _guestService.CheckGuestIsStayedAsync(guestId);
        return Ok(result);
    }
} 