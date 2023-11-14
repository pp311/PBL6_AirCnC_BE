using AirCnC.Application.Commons;
using AirCnC.Domain.Enums;
using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.HostPayments.Dtos;

public class HostPaymentQueryParameters:PagingParameters
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public HostPaymentStatus? Status { get; set; }
}