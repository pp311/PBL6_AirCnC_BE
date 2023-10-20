namespace AirCnC.Application.Services.Hosts.Dtos;

public class GetHostDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string? Introduction { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public DateTime JoinedAt { get; set; }
    public int NumberOfReviews { get; set; }
}