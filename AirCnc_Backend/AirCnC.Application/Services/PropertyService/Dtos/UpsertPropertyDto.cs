using AirCnC.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.PropertyService.Dtos
{
    public class UpsertPropertyDto
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(PropertyType))]
        public PropertyType Type { get; set; }
        
        [Required]
        [Range(1, 10)]
        public int BedCount { get; set; }
        
        [Required]
        [Range(1, 10)]
        public int BedroomCount { get; set; }
        
        [Required]
        [Range(1, 10)]
        public int BathroomCount { get; set; }
        
        [Required]
        [Range(1, 10)]
        public int MaxAdultCount { get; set; }
        
        [Required]
        [Range(0, 10)]
        public int MaxChildCount { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        [Required]
        public double Latitude { get; set; }
        
        [Required]
        public double Longitude { get; set; }
        
        [Required]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        public string City { get; set; } = string.Empty;
        
        [Required]
        public double PricePerNight { get; set; }
        
        [Required]
        public double CleaningFee { get; set; }
        
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(CancellationPolicyType))]
        public CancellationPolicyType CancellationPolicyType { get; set; }

        [Required]
        public ICollection<UpsertPropertyImageDto> PropertyImages { get; set; } = new List<UpsertPropertyImageDto>();
        
        [Required]
        public ICollection<PropertyUtilityDto> PropertyUtilities { get; set; } = new List<PropertyUtilityDto>();
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(PropertyStatus))]
        public PropertyStatus Status { get; set; } = PropertyStatus.Pending;
        public string? RejectionReason { get; set; }
    }
}
