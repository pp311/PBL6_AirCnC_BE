using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Bookings.Dtos;

public class GetBookingForPropertyDto
{
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public BookingStatus Status { get; set; }
}