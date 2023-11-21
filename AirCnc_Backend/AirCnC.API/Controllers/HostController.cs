using AirCnC.Application.Commons;
using AirCnC.Application.Services.Hosts;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet("{hostId:int}")]
    public async Task<IActionResult> GetHostAsync(int hostId)
    {
        var host = await _hostService.GetHostAsync(hostId);
        return Ok(host);
    }
    [HttpGet]
    public async Task<IActionResult> GetHostAsync([FromQuery] PagingParameters pp)
    {
        var hosts = await _hostService.GetHostsAsync(pp);
        return Ok(hosts);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetHostByUserIdAsync(int userId)
    {
        var host = await _hostService.GetHostByUserIdAsync(userId);
        return Ok(host);
    }
    
    [HttpGet("{hostId:int}/is-stayed")]
    [Authorize]
    public async Task<IActionResult> CheckHostIsStayed(int hostId)
    {
        var result = await _hostService.CheckHostIsStayedAsync(hostId);
        return Ok(result);
    }
}
