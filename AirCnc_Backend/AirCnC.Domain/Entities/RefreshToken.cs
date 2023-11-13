using AirCnC.Domain.Entities.Base;

namespace AirCnC.Domain.Entities;

public class RefreshToken : EntityBase
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.Now >= Expires;
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}