using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class HostReviewConfiguration : IEntityTypeConfiguration<HostReview>
{
    public void Configure(EntityTypeBuilder<HostReview> builder)
    {
        builder.Property(hr => hr.Content)
            .IsRequired()
            .HasMaxLength(StringLength.ReviewContent);

        builder.HasOne(hr => hr.Guest)
            .WithMany(g => g.HostReviews)
            .HasForeignKey(hr => hr.GuestId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(hr => hr.Host)
            .WithMany(h => h.HostReviews)
            .HasForeignKey(hr => hr.HostId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}