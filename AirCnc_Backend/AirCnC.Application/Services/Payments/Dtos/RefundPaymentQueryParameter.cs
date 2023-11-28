using AirCnC.Application.Commons;
using AirCnC.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AirCnC.Application.Services.Payments.Enums;

namespace AirCnC.Application.Services.Payments.Dtos;

public class RefundPaymentQueryParameter: PagingParameters
{
    public int? UserId { get; set; }

    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RefundPaymentStatus? Status { get; set; }
    public PaymentSortBy? OrderBy { get; set; }

}