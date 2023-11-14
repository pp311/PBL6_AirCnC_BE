using Microsoft.AspNetCore.Identity;

namespace AirCnC.Domain.Entities;

public class User : IdentityUser<int>
{
    public string FullName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Introduction { get; set; }
    
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    
    public ICollection<Message> SentMessages { get; set; } = new List<Message>();
    public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();

    public Guest Guest { get; set; } = null!;
    public Host? Host { get; set; }
}