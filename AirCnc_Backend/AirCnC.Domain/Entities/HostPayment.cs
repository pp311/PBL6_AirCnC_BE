using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class HostPayment : EntityBase
{
    public int PaymentInfoId { get; set; }
    public PaymentInfo PaymentInfo { get; set; } = null!;
    
    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    
    public HostPaymentStatus Status { get; set; }
    
    public double Amount { get; set; }
    
    public string? Description { get; set; } 
}
