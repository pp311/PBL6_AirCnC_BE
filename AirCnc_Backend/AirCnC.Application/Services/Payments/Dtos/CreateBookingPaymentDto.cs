

using AirCnC.Domain.Enums;

namespace AirCnC.Application.Services.Payments.Dtos
{
    public class CreateBookingPaymentDto
    {
        public int GuestId { get; set; }
        public int BookingId { get; set; }
        public string BankCode { get; set; } = "VNBANK";
        public string OrderDesc { get; set; }
        public long Amount { get; set; }


    }
}