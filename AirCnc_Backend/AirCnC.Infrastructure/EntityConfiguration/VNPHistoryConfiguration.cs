using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class VNPHistoryConfiguration : IEntityTypeConfiguration<VNPHistory>
{
    public void Configure(EntityTypeBuilder<VNPHistory> builder)
    {
        builder.HasOne(vnp=>vnp.BookingPayment)
            .WithMany(bp=>bp.VnpHistories)
            .HasForeignKey(vnp=>vnp.BookingPaymentId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}