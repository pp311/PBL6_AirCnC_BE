using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Payments.Dtos;

public class GetChargePaymentDto
{
    public string PaymentCode { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; }
    public double Amount { get; set; }
    public DateTime CreateAt { get; set; }
    public ChargePaymentStatus Status { get; set; }
}