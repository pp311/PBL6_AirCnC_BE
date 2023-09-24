using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class Booking : EntityBase
{
    public int PropertyId { get; set; }
    public Property Property { get; set; } = null!;
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    
    public int NumberOfAdults { get; set; }
    public int NumberOfChildren { get; set; }
    
    public string? Note { get; set; }
    
    public BookingStatus Status { get; set; }
    
    public double PricePerNight { get; set; }
    public double CleaningFee { get; set; }
    public double SystemFee { get; set; }
    public double TotalPrice { get; set; }
    
    public int? CancellationTicketId { get; set; }
    public CancellationTicket? CancellationTicket { get; set; }
    
    public int? BookingPaymentId { get; set; }
    public BookingPayment? BookingPayment { get; set; }
    
    public int? HostPaymentId { get; set; }
    public HostPayment? HostPayment { get; set; }
}