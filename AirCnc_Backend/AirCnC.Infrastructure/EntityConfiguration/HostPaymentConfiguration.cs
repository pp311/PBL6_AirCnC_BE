using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class HostPaymentConfiguration : IEntityTypeConfiguration<HostPayment>
{
    public void Configure(EntityTypeBuilder<HostPayment> builder)
    {
        builder.Property(hp => hp.Amount)
            .IsRequired();

        builder.Property(hp => hp.Status)
            .HasConversion(
                v => v.ToString(),
                v => (HostPaymentStatus)Enum.Parse(typeof(HostPaymentStatus), v));

        builder.Property(hp => hp.Description)
            .HasMaxLength(StringLength.Description);

        builder.HasOne(hp => hp.Booking)
            .WithOne(b => b.HostPayment)
            .HasForeignKey<HostPayment>(hp => hp.BookingId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(hp => hp.PaymentInfo)
            .WithMany(pi => pi.HostPayments)
            .HasForeignKey(hp => hp.PaymentInfoId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}