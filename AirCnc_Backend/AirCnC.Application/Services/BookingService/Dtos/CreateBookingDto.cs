using System.ComponentModel.DataAnnotations;
using AirCnC.Domain.Constants;

namespace AirCnC.Application.Services.BookingService.Dtos;

public class CreateBookingDto
{
    public int PropertyId { get; set; }
    public int GuestId { get; set; }
    
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    
    [Range(1, 10)]
    public int NumberOfAdults { get; set; }
    [Range(0, 10)]
    public int NumberOfChildren { get; set; }
    [MaxLength(StringLength.Description)]
    public string? Note { get; set; }
}