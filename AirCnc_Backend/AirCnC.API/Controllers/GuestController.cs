using AirCnC.Application.Services.Guests;
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
} 