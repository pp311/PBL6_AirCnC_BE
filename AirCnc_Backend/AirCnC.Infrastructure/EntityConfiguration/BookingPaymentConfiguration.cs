using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class BookingPaymentConfiguration : IEntityTypeConfiguration<BookingPayment>
{
    public void Configure(EntityTypeBuilder<BookingPayment> builder)
    {
        builder.Property(bp => bp.Amount)
            .IsRequired();

        builder.Property(bp => bp.PaymentCode)
            .IsRequired()
            .HasMaxLength(StringLength.PaymentCode);

        builder.Property(bp => bp.Status)
            .HasConversion(
                v => v.ToString(),
                v => (BookingPaymentStatus)Enum.Parse(typeof(BookingPaymentStatus), v));

        builder.Property(bp => bp.Description)
            .HasMaxLength(StringLength.Description);

        builder.HasOne(bp => bp.Booking)
            .WithOne(b => b.BookingPayment)
            .HasForeignKey<BookingPayment>(bp => bp.BookingId)
            .OnDelete(DeleteBehavior.NoAction);  
    }
}