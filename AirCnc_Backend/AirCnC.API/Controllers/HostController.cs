using AirCnC.Application.Commons;
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
    [HttpGet]
    public async Task<IActionResult> GetHostAsync([FromQuery] PagingParameters pp)
    {
        var hosts = await _hostService.GetHostsAsync(pp);
        return Ok(hosts);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetHostByUserIdAsync(int userId)
    {
        var host = await _hostService.GetHostByUserIdAsync(userId);
        return Ok(host);
    }
}
