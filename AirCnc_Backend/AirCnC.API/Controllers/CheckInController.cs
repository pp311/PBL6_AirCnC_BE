using AirCnC.Application.Services.CheckIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[Route("api/check-in")]
[ApiController]
public class CheckInController : ControllerBase
{
    private readonly ICheckInService _checkInService;

    public CheckInController(ICheckInService checkInService)
    {
        _checkInService = checkInService;
    }

    [HttpPost("{code:guid}")]
    [Authorize]
    public async Task<IActionResult> CheckIn(Guid code)
    {
        var result= await _checkInService.CheckInAsync(code);
        return Ok(result);
    }
}
