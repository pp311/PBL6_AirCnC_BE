using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class PropertyUtilityConfiguration : IEntityTypeConfiguration<PropertyUtility>
{
    public void Configure(EntityTypeBuilder<PropertyUtility> builder)
    {
        builder.HasOne(pu => pu.Property)
            .WithMany(p => p.PropertyUtilities)
            .HasForeignKey(pu => pu.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}