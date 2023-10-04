using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.PropertyService.Enums;
using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.PropertyService.Dtos;

public class PropertyQueryParameters : PagingParameters
{
    [EnumDataType(typeof(PropertyType))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PropertyType? Type { get; set; }

    [EnumDataType(typeof(PropertySortBy))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PropertySortBy? OrderBy { get; set; }
}
