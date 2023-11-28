using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Payments.Dtos;

public class GetRefundPaymentDto
{
    public string PaymentCode { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; }
    public double Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public RefundPaymentStatus Status { get; set; }
}