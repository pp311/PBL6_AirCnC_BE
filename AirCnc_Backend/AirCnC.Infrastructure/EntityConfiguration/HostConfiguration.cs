using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.HasOne(h => h.User)
            .WithOne(u => u.Host)
            .HasForeignKey<Host>(h => h.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(h => h.Properties)
            .WithOne(p => p.Host)
            .HasForeignKey(p => p.HostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}