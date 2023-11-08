using System.Text.Json.Serialization;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Cancellations.Dtos;

public class CreateCancellationDto
{
    public int BookingId { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CancellationReason CancellationReason { get; set; } = CancellationReason.Other;
    public string? Reason { get; set; }

    public bool IsGuest { get; set; }
    
    public List<string> Attachments { get; set; } = new();
}