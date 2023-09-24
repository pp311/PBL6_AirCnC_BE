using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class CancellationTicketConfiguration : IEntityTypeConfiguration<CancellationTicket>
{
    public void Configure(EntityTypeBuilder<CancellationTicket> builder)
    {
        builder.Property(ct => ct.CancellationReason)
            .HasConversion(
                v => v.ToString(),
                v => (CancellationReason)Enum.Parse(typeof(CancellationReason), v));
        
        builder.Property(ct => ct.Status)
            .HasConversion(
                v => v.ToString(),
                v => (CancellationTicketStatus)Enum.Parse(typeof(CancellationTicketStatus), v));
        
        builder.Property(ct => ct.CancellationReasonNote)
            .HasMaxLength(StringLength.Description);

        builder.Property(ct => ct.ResolveNote)
            .HasMaxLength(StringLength.Description);
        
        builder.HasOne(ct => ct.Booking)
            .WithOne(b => b.CancellationTicket)
            .HasForeignKey<CancellationTicket>(ct => ct.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}