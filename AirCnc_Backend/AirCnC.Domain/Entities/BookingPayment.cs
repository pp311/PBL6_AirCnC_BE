using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class BookingPayment : EntityBase
{
    public string PaymentCode { get; set; } = null!;
    
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    
    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    
    public double Amount { get; set; }
    
    public BookingPaymentStatus Status { get; set; }
    
    public string? Description { get; set; }
}