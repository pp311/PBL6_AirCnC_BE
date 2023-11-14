using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirCnC.Infrastructure.EntityConfiguration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(p => p.SenderName).IsRequired();
        builder.Property(p => p.Content).IsRequired().HasMaxLength(2048);
        builder.Property(p => p.SenderAvatarUrl).HasMaxLength(StringLength.Url);
        
        builder.HasOne(p => p.Sender)
            .WithMany(p => p.SentMessages)
            .HasForeignKey(p => p.SenderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Receiver)
            .WithMany(p => p.ReceivedMessages)
            .HasForeignKey(p => p.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}