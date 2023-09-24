using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class Property : EntityBase
{
    public int HostId { get; set; }
    public Host Host { get; set; } = null!;

    public PropertyType Type { get; set; }
    
    public int BedCount { get; set; }
    public int BathroomCount { get; set; }
    public int MaxAdultCount { get; set; }
    public int MaxChildCount { get; set; }
    
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    
    public double PricePerNight { get; set; }
    public double CleaningFee { get; set; }
    
    public int CancellationPolicyId { get; set; }
    public CancellationPolicy CancellationPolicy { get; set; } = null!;
    
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
    public ICollection<PropertyReview> PropertyReviews { get; set; } = new List<PropertyReview>();
    public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    public ICollection<PropertyUtility> PropertyUtilities { get; set; } = new List<PropertyUtility>();
}