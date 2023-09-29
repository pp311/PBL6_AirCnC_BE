using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(StringLength.Title);

        builder.Property(p => p.Description)
            .HasMaxLength(StringLength.Description);
        
        builder.Property(p => p.Longitude)
            .HasPrecision(13, 10)
            .IsRequired();

        builder.Property(p => p.Latitude)
            .HasPrecision(13, 10)
            .IsRequired();
        
        builder.Property(p => p.PricePerNight)
            .IsRequired();
        
        builder.Property(p => p.CleaningFee)
            .IsRequired();

        builder.Property(p => p.Type)
            .HasConversion(
                v => v.ToString(),
                v => (PropertyType)Enum.Parse(typeof(PropertyType), v));

        builder.Property(Property => Property.CancellationPolicyId).IsRequired(false);
        builder.HasOne(p => p.CancellationPolicy)
            .WithMany(cp => cp.Properties)
            .HasForeignKey(p => p.CancellationPolicyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Host)
            .WithMany(h => h.Properties)
            .HasForeignKey(p => p.HostId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}