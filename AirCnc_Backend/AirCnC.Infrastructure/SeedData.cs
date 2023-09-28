using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Bogus;
using Bogus.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace AirCnC.Infrastructure;

public static class SeedData
{
    public class FakePropertyImgUrl
    {
        public string? tittle { get; set; } 
        public List<string>? urlImgs { get; set; }
       
    }
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
        
        // seed users
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
        // seed hosts
        var HostUsers = users;
        var hosts = new Faker<Host>()
            .RuleFor(h => h.UserId, f => {
                var user = f.PickRandom(HostUsers);
                HostUsers.Remove(user);
                return user.Id;
            })
            .RuleFor(h => h.Id, f => f.IndexFaker + 1)
            .Generate(5);
        foreach (var host in hosts)
        {
            modelBuilder.Entity<Host>().HasData(host);
        }
        //seed properties
        var properties = new Faker<Property>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.HostId, f => f.PickRandom(hosts).Id)
            .RuleFor(p => p.Type, f => f.PickRandom<PropertyType>())
            .RuleFor(p => p.BedCount, f => f.Random.Number(1, 5))
            .RuleFor(p => p.BathroomCount, f => f.Random.Number(1, 3))
            .RuleFor(p => p.MaxAdultCount, f => f.Random.Number(1, 10))
            .RuleFor(p => p.MaxChildCount, f => f.Random.Number(1, 10))
            .RuleFor(p => p.Title, f => f.Lorem.Sentence(10,20))
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .RuleFor(p => p.Latitude, f => f.Address.Latitude())
            .RuleFor(p => p.Longitude, f => f.Address.Longitude())
            .RuleFor(p => p.PricePerNight, f => f.Random.Double(10, 100))
            .RuleFor(p => p.CleaningFee, f => f.Random.Double(10, 100))
            .Generate(30);
        foreach (var property in properties)
        {
            modelBuilder.Entity<Property>().HasData(property);
        }
        //seed property imgs
        List<FakePropertyImgUrl> fakePropertyImgUrls = JsonSerializer.Deserialize<List<FakePropertyImgUrl>>(File.ReadAllText("..\\AirCnC.Infrastructure\\data.json"));
        int IndexFakePropertyImgUrl = 0;
        int IndexPropertyImg = 0;
        List<PropertyImage> propertyImages = new List<PropertyImage>();
        foreach (var property in properties)
        {
            for(int i = 0; i < fakePropertyImgUrls[IndexFakePropertyImgUrl].urlImgs.Count; i++)
            {
                propertyImages.Add(new PropertyImage
                {
                    Id = IndexPropertyImg + 1,
                    PropertyId = property.Id,
                    Url = fakePropertyImgUrls[IndexFakePropertyImgUrl].urlImgs[i]
                });
                IndexPropertyImg++;
            }
            IndexFakePropertyImgUrl++;
        }


        foreach (var propertyImage in propertyImages)
        {
            modelBuilder.Entity<PropertyImage>().HasData(propertyImage);
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