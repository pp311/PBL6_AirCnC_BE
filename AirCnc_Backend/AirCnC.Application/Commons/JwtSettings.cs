namespace AirCnC.Application.Commons;

public class JwtSettings
{
    public string SecurityKey { get; set; } = null!;
    public string ValidIssuer { get; set; } = null!;
    public string ValidAudience { get; set; } = null!;
    public double AccessTokenExpiryInMinutes { get; set; }
    public double RefreshTokenExpiryInMinutes { get; set; }
}