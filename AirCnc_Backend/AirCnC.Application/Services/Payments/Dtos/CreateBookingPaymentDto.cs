namespace AirCnC.Application.Services.Payments.Dtos
{
    public class CreateBookingPaymentDto
    {
        public int BookingId { get; set; }
        public string? BankCode { get; set; } = "VNBANK";
    }
}