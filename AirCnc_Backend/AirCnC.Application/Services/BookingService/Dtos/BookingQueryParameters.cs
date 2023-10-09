using System.Text.Json.Serialization;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.BookingService.Enums;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.BookingService.Dtos;

public class BookingQueryParameters : PagingParameters
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BookingSortBy? OrderBy { get; set; } 
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BookingStatus? Status { get; set; }
}