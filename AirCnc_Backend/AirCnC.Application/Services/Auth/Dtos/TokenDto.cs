using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.Auth.Dtos;

public class TokenDto
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!; 
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GetUserDto User { get; set; } = null!;
    public string Role { get; set; } = null!;
}