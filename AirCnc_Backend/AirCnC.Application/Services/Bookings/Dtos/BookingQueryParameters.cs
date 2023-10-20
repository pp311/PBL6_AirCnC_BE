using System.Text.Json.Serialization;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Bookings.Enums;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Bookings.Dtos;

public class BookingQueryParameters : PagingParameters
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BookingSortBy? OrderBy { get; set; } 
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BookingStatus? Status { get; set; }
}