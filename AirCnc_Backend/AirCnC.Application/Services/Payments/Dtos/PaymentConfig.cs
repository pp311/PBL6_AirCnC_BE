namespace AirCnC.Application.Services.Payments.Dtos
{
    public class PaymentConfig
    {
        public string VnpReturnUrl { get; set; } = null!;
        public string VnpUrl { get; set; } = null!;
        public string VnpTmnCode { get; set; } = null!;
        public string VnpHashSecret { get; set; } = null!;

        public override string ToString()
        {
            return String.Format("PaymentInfo (VNPReturnURL={0}, VNPUrl={1}, VNPTmnCode={2}, VNPHashSecret={3}",
                VnpReturnUrl, VnpUrl, VnpTmnCode, VnpHashSecret);
        }
    }
}