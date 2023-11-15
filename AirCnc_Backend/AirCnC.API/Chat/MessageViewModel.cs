using System.ComponentModel.DataAnnotations;

namespace AirCnC.API.Chat;

public class MessageViewModel
 {
     public int FromUserId { get; set; }
     public string FromUserName { get; set; } = null!;
     public string? FromUserAvatar { get; set; } 
     public int ToUserId { get; set; }
     public string Content { get; set; } = null!;
 }