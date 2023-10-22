using System.Text.Json.Serialization;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Reviews.Enums;

namespace AirCnC.Application.Services.Reviews.Dtos;

public class ReviewQueryParameters : PagingParameters
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ReviewSortBy? OrderBy { get; set; }
}