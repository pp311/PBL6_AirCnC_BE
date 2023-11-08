namespace AirCnC.Application.Services.Users.Dtos;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? AvatarUrl { get; set; }
}