using System.ComponentModel.DataAnnotations;

namespace AirCnC.API.Chat;

public class MessageViewModel
 {
     public int Id { get; set; }
     [Required]
     public string Content { get; set; } = null!;
     public string? FromUserName { get; set; }
     [Required]
     public string Room { get; set; } = null!;
     public string? Avatar { get; set; } 
 }