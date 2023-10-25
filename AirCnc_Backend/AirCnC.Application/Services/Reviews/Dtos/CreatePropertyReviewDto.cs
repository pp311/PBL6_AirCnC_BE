using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.Reviews.Dtos;

public class CreatePropertyReviewDto
{
    [JsonIgnore]
    public int GuestId { get; set; }
    [JsonIgnore]
    public int PropertyId { get; set; }
    
    [Range(1, 5)]
    public int Cleanliness { get; set; }
    [Range(1, 5)]
    public int Communication { get; set; }
    [Range(1, 5)]
    public int CheckIn { get; set; }
    [Range(1, 5)]
    public int Accuracy { get; set; }
    [Range(1, 5)]
    public int Location { get; set; }
    [Range(1, 5)]
    public int Value { get; set; }
    
    public string Content { get; set; } = string.Empty;
}