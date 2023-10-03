using AirCnC.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [Authorize]
    [HttpGet("anyone")]
    public IActionResult Get()
    {
        return Ok("Hello World");
    } 
    
    [Authorize(Roles = AppRole.Admin)]
    [HttpGet("admin")]
    public IActionResult GetAdmin()
    {
        return Ok("Hello Admin");
    }
    
    [HttpGet("allow-anonymous")]
    [AllowAnonymous]
    public IActionResult GetAllowAnonymous()
    {
        return Ok("Hello Anonymous");
    }
}