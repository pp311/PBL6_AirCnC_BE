namespace AirCnC.Application.Services.Reviews.Dtos;

public class GetReviewDto
{
    public int Id { get; set; } 
    public int ReviewerId { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public string? ReviewerAvatarUrl { get; set; } = string.Empty;
    public DateTime ReviewTime { get; set; } 
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
}