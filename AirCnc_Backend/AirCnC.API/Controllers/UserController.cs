using AirCnC.Application.Commons;
using AirCnC.Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]

[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var result = await _userService.GetUserAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserList([FromQuery] PagingParameters pqp)
    {
        var result = await _userService.GetUsersAsync(pqp);
        return Ok(result);
    }
}