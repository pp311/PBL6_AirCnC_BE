using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class CancellationPolicyConfiguration : IEntityTypeConfiguration<CancellationPolicy>
{
    public void Configure(EntityTypeBuilder<CancellationPolicy> builder)
    {
        builder.Property(cp => cp.Type)
            .HasConversion(
                v => v.ToString(),
                v => (CancellationPolicyType)Enum.Parse(typeof(CancellationPolicyType), v));

        builder.Property(cp => cp.Description)
            .HasMaxLength(StringLength.Description);
    }
}