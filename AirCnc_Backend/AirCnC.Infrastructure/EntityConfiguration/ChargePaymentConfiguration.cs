using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class ChargePaymentConfiguration : IEntityTypeConfiguration<ChargePayment>
{
    public void Configure(EntityTypeBuilder<ChargePayment> builder)
    {
        builder.Property(cp => cp.PaymentCode)
            .IsRequired()
            .HasMaxLength(StringLength.PaymentCode);

        builder.Property(cp => cp.BookingPaymentCode)
            .IsRequired()
            .HasMaxLength(StringLength.PaymentCode);

        builder.Property(cp => cp.Amount)
            .IsRequired();

        builder.Property(cp => cp.Status)
            .HasConversion(
                v => v.ToString(),
                v => (Domain.Enums.ChargePaymentStatus)Enum.Parse(typeof(Domain.Enums.ChargePaymentStatus), v));

        builder.HasOne(cp => cp.Host)
            .WithMany(h => h.ChargePayments)
            .HasForeignKey(cp => cp.HostId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(cp => cp.CancellationTicket)
            .WithOne(ct => ct.ChargePayment)
            .HasForeignKey<ChargePayment>(cp => cp.CancellationTicketId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}