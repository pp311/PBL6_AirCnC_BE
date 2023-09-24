using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.Infrastructure;

public static class SeedData
{
    public static void AddIdentitySeedData(this ModelBuilder modelBuilder)
        {
            var roles = GetDefaultRoles();
            foreach (var role in roles)
            {
                modelBuilder.Entity<IdentityRole<int>>().HasData(role);
            }
            
            var admin = GetAdmin();
            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> {RoleId = roles[0].Id, UserId = admin.Id});
            
            var users = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 3)
                .RuleFor(u => u.FullName, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.UserName, (_, u) => u.Email)
                .RuleFor(u => u.SecurityStamp, _ => Guid.NewGuid().ToString())
                .Generate(10);
    
            foreach (var user in users)
            {
                modelBuilder.Entity<User>().HasData(user);
                modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> {RoleId = roles[1].Id, UserId = user.Id});
            }
        }
    
        private static List<IdentityRole<int>> GetDefaultRoles()
        {
            var roles = new List<IdentityRole<int>>
            {
                new() { Id = 1, Name = AppRole.Admin, NormalizedName = AppRole.Admin.ToUpper() },
                new() { Id = 2, Name = AppRole.User, NormalizedName = AppRole.User.ToUpper() }
            };
            return roles;
        }
    
        private static User GetAdmin()
        {
            return new User
            {
                FullName = "Phuc Phan",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                Id = 1,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = new PasswordHasher<User>().HashPassword(null!, "Admin@123")
            };
        }
}