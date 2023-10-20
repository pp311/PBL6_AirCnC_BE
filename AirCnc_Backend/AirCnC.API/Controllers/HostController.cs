using AirCnC.Application.Services.Hosts;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]
[Route("api/hosts")]
public class HostController : ControllerBase
{
    private readonly IHostService _hostService;

    public HostController(IHostService hostService)
    {
        _hostService = hostService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHostAsync(int id)
    {
        var host = await _hostService.GetHostAsync(id);
        return Ok(host);
    }
}
