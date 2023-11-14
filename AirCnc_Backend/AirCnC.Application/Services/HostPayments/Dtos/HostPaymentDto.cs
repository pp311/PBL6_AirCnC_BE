using AirCnC.Domain.Enums;
using System.Text.Json.Serialization;

namespace AirCnC.Application.Services.HostPayments.Dtos
{
    public class HostPaymentDto
    {
        public int Id { get; set; }
        public HostPaymentInfoDto PaymentInfo { get; set; } = null!;

        public int BookingId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HostPaymentStatus Status { get; set; }

        public double Amount { get; set; }

        public string? Description { get; set; }
    }
}
