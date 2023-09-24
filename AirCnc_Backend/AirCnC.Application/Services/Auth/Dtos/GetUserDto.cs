namespace AirCnC.Application.Services.Auth.Dtos;

public class GetUserDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
}