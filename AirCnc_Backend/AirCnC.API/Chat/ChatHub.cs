using System.Security.Claims;
using System.Text.RegularExpressions;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AirCnC.API.Chat;

public class ChatHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("UserConnected", $"Context.ConnectionId");
    }

    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    [Authorize]
    public async Task SendMessageToUser(string user, string message, 
                                        IRepository<Message> chatRepository, 
                                        IUnitOfWork unitOfWork)
    {
        var senderId = Context.User!.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var messageEntity = new Message()
        {
            SenderId = int.Parse(senderId!),
            SenderAvatarUrl = Context.User!.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Uri)?.Value,
            SenderName = Context.User!.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value!,
            ReceiverId = int.Parse(user),
            Content = message
        };
        
        chatRepository.Add(messageEntity);
        await unitOfWork.SaveChangesAsync();
        
        var messageViewModel = new MessageViewModel
        {
            Content = Regex.Replace(message, @"<.*?>", string.Empty),
            FromUserName = Context.User?.Identity?.Name,
            Avatar = Context.User!.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Uri)?.Value,
        };
        await Clients.User(user).SendAsync("ReceiveMessage", messageViewModel);
        await Clients.Caller.SendAsync("ReceiveMessage", messageViewModel);
    }
}