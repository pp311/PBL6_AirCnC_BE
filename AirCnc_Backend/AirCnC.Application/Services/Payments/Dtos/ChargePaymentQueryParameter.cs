using AirCnC.Application.Commons;
using AirCnC.Application.Services.Payments.Enums;
using AirCnC.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.Payments.Dtos;

public class ChargePaymentQueryParameter: PagingParameters
{
    public int? UserId { get; set; }

    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ChargePaymentStatus? Status { get; set; }
    public PaymentSortBy? OrderBy { get; set; }

}