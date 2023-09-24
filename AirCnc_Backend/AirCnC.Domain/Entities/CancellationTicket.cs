using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class CancellationTicket : EntityBase
{
    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    
    // Trong Auditable da co created by, chinh la issuer id
    // public int IssuerId { get; set; }
    public int TheOtherPartyId { get; set; }
    public bool IsIssuerGuest { get; set; }
    
    public CancellationReason CancellationReason { get; set; }
    public string? CancellationReasonNote { get; set; }
    
    public CancellationTicketType Type { get; set; }
    
    public CancellationTicketStatus Status { get; set; }
    
    public string? ResolveNote { get; set; }
    
    // for guest
    public double RefundAmount { get; set; }
    
    // for host
    public double ChargeAmount { get; set; }
    
    public ICollection<CancellationTicketAttachment> Attachments { get; set; } = null!;
    
    public int? RefundPaymentId { get; set; }
    public RefundPayment? RefundPayment { get; set; }
    
    public int? ChargePaymentId { get; set; }
    public ChargePayment? ChargePayment { get; set; }
}