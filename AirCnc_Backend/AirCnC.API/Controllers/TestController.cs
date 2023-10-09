using AirCnC.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    /// <summary>
    /// Đã login thì mới vào được
    /// </summary>
    [Authorize]
    [HttpGet("anyone")]
    public IActionResult Get()
    {
        return Ok("Hello World");
    } 
    
    /// <summary>
    /// Phải login và có role là Admin thì mới vào được
    /// </summary>
    [Authorize(Roles = AppRole.Admin)]
    [HttpGet("admin")]
    public IActionResult GetAdmin()
    {
        return Ok("Hello Admin");
    }
    
    /// <summary>
    /// Anonymous có nghĩa là không cần login cũng vào được
    /// </summary>
    [HttpGet("allow-anonymous")]
    [AllowAnonymous]
    public IActionResult GetAllowAnonymous()
    {
        return Ok("Hello Anonymous");
    }
}