using AirCnC.Domain.Entities;
using AirCnC.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.Infrastructure.Data;

public class AirCnCDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public AirCnCDbContext(DbContextOptions<AirCnCDbContext> options) : base(options)
    {
    }
    
    public DbSet<Booking> Bookings { get; set; } = null!;
    public DbSet<Wishlist> Wishlists { get; set; } = null!;
    
    public DbSet<CancellationTicket> CancellationTickets { get; set; } = null!;
    public DbSet<CancellationTicketAttachment> CancellationTicketAttachments { get; set; } = null!;
    
    public DbSet<Property> Properties { get; set; } = null!;
    public DbSet<PropertyReview> PropertyReviews { get; set; } = null!;
    public DbSet<PropertyImage> PropertyImages { get; set; } = null!;
    public DbSet<PropertyUtility> PropertyAmenities { get; set; } = null!;
    
    public DbSet<Host> Hosts { get; set; } = null!;
    public DbSet<Guest> Guests { get; set; } = null!;
    public DbSet<HostReview> HostReviews { get; set; } = null!;
    public DbSet<GuestReview> GuestReviews { get; set; } = null!;
    
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    
    public DbSet<PaymentInfo> PaymentInfos { get; set; } = null!;
    public DbSet<BookingPayment> Payments { get; set; } = null!;
    public DbSet<ChargePayment> ChargePayments { get; set; } = null!;
    public DbSet<RefundPayment> RefundPayments { get; set; } = null!;
    public DbSet<HostPayment> HostPayments { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddIdentitySeedData();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirCnCDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditableEntityProperties();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void SetAuditableEntityProperties()
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    // entry.Entity.CreatedBy = _currentUser.Id;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    // entry.Entity.LastModifiedBy = _currentUser.Id;
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.LastModifiedAt = DateTime.UtcNow;
                    entry.Entity.IsDeleted = true;
                    break;
            }
        }
    }
}