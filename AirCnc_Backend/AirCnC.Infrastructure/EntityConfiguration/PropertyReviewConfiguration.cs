using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class PropertyReviewConfiguration : IEntityTypeConfiguration<PropertyReview>
{
    public void Configure(EntityTypeBuilder<PropertyReview> builder)
    {
        builder.Property(pr => pr.Content)
            .IsRequired()
            .HasMaxLength(StringLength.ReviewContent);

        builder.HasOne(pr => pr.Guest)
            .WithMany(g => g.PropertyReviews)
            .HasForeignKey(pr => pr.GuestId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(pr => pr.Property)
            .WithMany(p => p.PropertyReviews)
            .HasForeignKey(pr => pr.PropertyId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}