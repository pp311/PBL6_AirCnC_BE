using AirCnC.Domain.Enums;
using Newtonsoft.Json;

namespace AirCnC.Application.Services.Properties.Dtos
{
    public class GetPropertyDto
    {
        public int Id { get; set; }
        public PropertyType Type { get; set; }

        public int BedCount { get; set; }
        public int BathroomCount { get; set; }
        public int MaxAdultCount { get; set; }
        public int MaxChildCount { get; set; }
        
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        
        public bool IsFavorite { get; set; }
        
        public int HostId { get; set; }
        public string HostName { get; set; } = string.Empty;
        
        public double Rating { get; set; }
        public int NumberOfReviews { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double PricePerNight { get; set; }
        public double CleaningFee { get; set; } 
        
        public ICollection<GetPropertyImageDto>? PropertyImages { get; set; }
        
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]        
        public ICollection<GetPropertyUtilityDto>? PropertyUtilities { get; set; }
        
        public PropertyStatus Status { get; set; }
        public string? RejectionReason { get; set; }
    }
}
