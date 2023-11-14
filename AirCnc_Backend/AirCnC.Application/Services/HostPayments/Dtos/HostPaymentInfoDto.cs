namespace AirCnC.Application.Services.HostPayments.Dtos
{
    public class HostPaymentInfoDto
    {
        public int HostId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountHolder { get; set; } = string.Empty;
    }
}
