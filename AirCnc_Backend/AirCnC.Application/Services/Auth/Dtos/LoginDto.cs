namespace AirCnC.Application.Services.Auth.Dtos;

public class LoginDto
{
    public string Identifier { get; set; } = null!;
    public string Password { get; set; } = null!; 
    
    public string? Role { get; set; }
}