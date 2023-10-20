using System.Text.Json.Serialization;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Bookings.Dtos;

public class GetBookingForGuestDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string PropertyName { get; set; } = null!;
    public int HostId { get; set; }
    public string HostName { get; set; } = null!;
    public string HostEmail { get; set; } = null!;
    public string HostPhoneNumber { get; set; } = null!;
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BookingStatus Status { get; set; }
    
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfDays { get; set; }
    public double PricePerNight { get; set; }
    public double TotalPrice { get; set; }
    
    public int NumberOfAdults { get; set; }
    public int NumberOfChildren { get; set; }
    public string? Note { get; set; }
}