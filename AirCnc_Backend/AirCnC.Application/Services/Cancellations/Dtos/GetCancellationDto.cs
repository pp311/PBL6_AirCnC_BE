using System.Text.Json.Serialization;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Cancellations.Dtos;

public class GetCancellationDto
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    
    public int IssuerId { get; set; }
    public int TheOtherPartyId { get; set; }
    public bool IsIssuerGuest { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CancellationReason CancellationReason { get; set; }
    public string? CancellationReasonNote { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CancellationTicketType Type { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CancellationTicketStatus Status { get; set; }
    
    public string? ResolveNote { get; set; }
    
    public double RefundAmount { get; set; }
    
    public double ChargeAmount { get; set; }
    
    public List<string> Attachments { get; set; } = new();
}