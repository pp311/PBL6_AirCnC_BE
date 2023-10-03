using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Enums.Sorting;

namespace AirCnC.Application.QueryParameters;

public class PropertyQueryParameters : PagingParameters
{
    [EnumDataType(typeof(PropertyType))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PropertyType? Type { get; set; }

    [EnumDataType(typeof(PropertySortBy))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PropertySortBy? OrderBy { get; set; }
}
