namespace AirCnC.Application.Services.Chat.Dtos;

public class GetMessageDto
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string SenderName { get; set; } = string.Empty;
    public string? SenderAvatarUrl { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime MessageTime { get; set; }
}