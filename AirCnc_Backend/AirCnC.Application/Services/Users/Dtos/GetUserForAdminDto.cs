namespace AirCnC.Application.Services.Users.Dtos;

public class GetUserForAdminDto
{
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHost { get; set; }
}