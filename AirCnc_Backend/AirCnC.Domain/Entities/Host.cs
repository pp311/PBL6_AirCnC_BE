using AirCnC.Domain.Entities.Base;

namespace AirCnC.Domain.Entities;

public class Host : EntityBase
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    public bool IsBlocked { get; set; }
    
    public ICollection<HostReview> HostReviews { get; set; } = new List<HostReview>();
    public ICollection<Property> Properties { get; set; } = new List<Property>();
    public ICollection<GuestReview> GuestReviews { get; set; } = new List<GuestReview>();
    
    public ICollection<ChargePayment> ChargePayments { get; set; } = new List<ChargePayment>();
    
    public PaymentInfo PaymentInfo { get; set; } = null!;
}