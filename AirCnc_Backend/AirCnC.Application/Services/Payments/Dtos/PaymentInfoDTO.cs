namespace AirCnC.Application.Services.Payments.Dtos

{
    public class PaymentInfoDto
    {
        public long OrderId { get; set; }
        public long Amount { get; set; }
        public string OrderDesc { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = null!;

        public long PaymentTranId { get; set; }
        public string BankCode { get; set; } = null!;
        public string PayStatus { get; set; } = null!;
    }
}