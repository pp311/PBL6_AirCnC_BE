using AirCnC.Application.Services.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[ApiController]
[Route("api/chat")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }
    
    [HttpGet("contacts")]
    public async Task<IActionResult> GetContactsAsync()
    {
        var contacts = await _chatService.GetContactsAsync();
        return Ok(contacts);
    }
    
    [HttpGet("messages/{userId}")]
    public async Task<IActionResult> GetMessagesWithUserIdAsync(int userId)
    {
        var messages = await _chatService.GetMessagesWithUserIdAsync(userId);
        return Ok(messages);
    }
}