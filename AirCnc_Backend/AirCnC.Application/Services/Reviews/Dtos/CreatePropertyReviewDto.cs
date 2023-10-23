using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.Reviews.Dtos;

public class CreatePropertyReviewDto
{
    [JsonIgnore]
    public int GuestId { get; set; }
    [JsonIgnore]
    public int PropertyId { get; set; }
    
    public int Cleanliness { get; set; }
    public int Communication { get; set; }
    public int CheckIn { get; set; }
    public int Accuracy { get; set; }
    public int Location { get; set; }
    public int Value { get; set; }
    
    public string Content { get; set; } = string.Empty;
}