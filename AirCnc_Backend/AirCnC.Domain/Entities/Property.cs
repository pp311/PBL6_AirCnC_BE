using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class Property : EntityBase
{
    public int HostId { get; set; }
    public Host Host { get; set; } = null!;

    public PropertyType Type { get; set; }
    
    public int BedCount { get; set; }
    public int BedroomCount { get; set; }
    public int BathroomCount { get; set; }
    public int MaxAdultCount { get; set; }
    public int MaxChildCount { get; set; }
    
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    
    public double PricePerNight { get; set; }
    public double CleaningFee { get; set; }
    
    public CancellationPolicyType CancellationPolicyType { get; set; }
    
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
    public ICollection<PropertyReview> PropertyReviews { get; set; } = new List<PropertyReview>();
    public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    public ICollection<PropertyUtility> PropertyUtilities { get; set; } = new List<PropertyUtility>();
}