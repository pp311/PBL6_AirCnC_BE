using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Properties.Enums;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Properties.Dtos;

public class PropertyQueryParameters : PagingParameters
{
    // Search theo loai phong
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public List<PropertyType>? Type { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PropertySortBy? OrderBy { get; set; }
    
    // Search theo khoang gia 
    public double MinPrice { get; set; } = 0;
    public double MaxPrice { get; set; } = 0;
    
    // Search theo so luong phong, so giuong, so phong tam
    [Range(0, 10)]
    public int MinBedroomCount { get; set; } = 0;
    [Range(0, 10)]
    public int MaxBedroomCount { get; set; } = 0;
    [Range(0, 10)]
    public int MinBedCount { get; set; } = 0;
    [Range(0, 10)]
    public int MaxBedCount { get; set; } = 0;
    [Range(0, 10)]
    public int MinBathroomCount { get; set; } = 0;
    [Range(0, 10)]
    public int MaxBathroomCount { get; set; } = 0;
    
    // Search theo khu vuc
    public string? City { get; set; }
    
    // Search theo khoang ngay
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    
    // Search theo so luong nguoi
    [Range(0, 64)]
    public int AdultCount { get; set; } = 0;
    [Range(0, 64)]
    public int ChildCount { get; set; } = 0;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PropertyStatus? Status { get; set; }
}
