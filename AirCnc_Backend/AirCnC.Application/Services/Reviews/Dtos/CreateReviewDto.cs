using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.Reviews.Dtos;

public class CreateReviewDto
{
    [JsonIgnore]
    public int ReviewerId { get; set; }
    [JsonIgnore]
    public int RevieweeId { get; set; }
    public int Rating { get; set; }
    public string Content { get; set; } = string.Empty;
}