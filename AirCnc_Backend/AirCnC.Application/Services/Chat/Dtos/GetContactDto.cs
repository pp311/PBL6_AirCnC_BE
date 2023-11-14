namespace AirCnC.Application.Services.Chat.Dtos;

public class GetContactDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; } = string.Empty;
    public string? LastMessage { get; set; } = string.Empty;
    public DateTime? LastMessageTime { get; set; }
}