namespace AirCnC.Application.Services.Bookings.Dtos;

public class GetDraftBookingDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string PropertyName { get; set; } = null!;
    
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfDays { get; set; }
    public double PricePerNight { get; set; }
    public double CleaningFee { get; set; }
    public double TotalPrice { get; set; }
    
    public int NumberOfAdults { get; set; }
    public int NumberOfChildren { get; set; }
    public string? Note { get; set; }
}