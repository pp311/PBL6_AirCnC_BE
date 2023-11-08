using System.Text.Json.Serialization;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Cancellations.Enums;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Cancellations.Dtos;

public class CancellationTicketQueryParameters : PagingParameters
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CancellationTicketSortBy? OrderBy { get; set; } 
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CancellationTicketStatus? Status { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CancellationTicketType? Type { get; set; }
    
    public bool? IsGuest { get; set; }
    public int? HostId { get; set; }
}