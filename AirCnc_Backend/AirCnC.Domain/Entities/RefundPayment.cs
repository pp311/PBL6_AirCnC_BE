using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class RefundPayment : EntityBase
{
    public string PaymentCode { get; set; } = null!;
    public string BookingPaymentCode { get; set; } = null!;
    
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    
    public int CancellationTicketId { get; set; }
    public CancellationTicket CancellationTicket { get; set; } = null!;
    
    public double Amount { get; set; }
    public RefundPaymentStatus Status { get; set; }
}