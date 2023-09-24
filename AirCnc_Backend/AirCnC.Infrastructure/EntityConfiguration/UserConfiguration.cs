using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(StringLength.Name);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(StringLength.Email);

        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(StringLength.PhoneNumber);

        builder.Property(p => p.Address)
            .HasMaxLength(StringLength.Address);

        builder.Property(p => p.City)
            .HasMaxLength(StringLength.City);

        builder.Property(p => p.State)
            .HasMaxLength(StringLength.State);
        
        builder.Property(p => p.Country)
            .HasMaxLength(StringLength.Country);

        builder.Property(p => p.AvatarUrl)
            .HasMaxLength(StringLength.Url);

        builder.Property(p => p.Introduction)
            .HasMaxLength(StringLength.Description);


    }
}