// ReSharper disable InconsistentNaming
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace AirCnC.Application.Services.Payments.Dtos
{
    public class VnPayReturnDto
    {
        public long vnp_Amount { get; set; }
        public string vnp_BankCode { get; set; }
        public string vnp_BankTranNo { get; set; }
        public string vnp_CardType { get; set; }
        public string vnp_OrderInfo { get; set; }
        public long vnp_PayDate { get; set; }
        public string vnp_ResponseCode { get; set; }
        public string vnp_TmnCode { get; set; }
        public string vnp_TransactionNo { get; set; }
        public string vnp_TransactionStatus { get; set; }
        public long vnp_TxnRef { get; set; }
        public string vnp_SecureHash { get; set; }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
