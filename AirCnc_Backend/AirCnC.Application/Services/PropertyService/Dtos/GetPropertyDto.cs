using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.PropertyService.Dtos
{
    public class GetPropertyDto
    {
        public int Id { get; set; }
        public PropertyType Type { get; set; }

        public int BedCount { get; set; }
        public int BathroomCount { get; set; }
        public int MaxAdultCount { get; set; }
        public int MaxChildCount { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double PricePerNight { get; set; }
        public ICollection<GetPropertyImageDto>? PropertyImages { get; set; }
        public ICollection<GetPropertyUtilityDto>? PropertyUtilities { get; set; }
    }
}
