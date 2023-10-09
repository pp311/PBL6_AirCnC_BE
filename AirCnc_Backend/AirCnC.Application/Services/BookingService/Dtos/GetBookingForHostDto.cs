using System.Text.Json.Serialization;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.BookingService.Dtos;

public class GetBookingForHostDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string PropertyName { get; set; } = null!;
    public int GuestId { get; set; }
    public string GuestName { get; set; } = null!;
    public string GuestEmail { get; set; } = null!;
    public string GuestPhoneNumber { get; set; } = null!;
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BookingStatus Status { get; set; }
    
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfDays { get; set; }
    public double PricePerNight { get; set; }
    
    public int NumberOfAdults { get; set; }
    public int NumberOfChildren { get; set; }
    public string? Note { get; set; }
}