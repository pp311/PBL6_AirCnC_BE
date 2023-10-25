using System.Text.Json;
using AirCnC.Domain.Constants;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.Infrastructure.Data;

public static class SeedData
{
    public class FakePropertyImgUrl
    {
        // ReSharper disable once InconsistentNaming
        public string? tittle { get; set; }

        // ReSharper disable once InconsistentNaming
        public List<string>? urlImgs { get; set; }

    }

    public static void AddIdentitySeedData(this ModelBuilder modelBuilder)
    {
        var roles = GetDefaultRoles();
        modelBuilder.Entity<IdentityRole<int>>().HasData(roles);

        var admin = GetAdmin();
        modelBuilder.Entity<User>().HasData(admin);
        modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            { RoleId = roles[0].Id, UserId = admin.Id });

        var users = GetUsers();

        foreach (var user in users)
        {
            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
                { RoleId = roles[1].Id, UserId = user.Id });
        }

        var guests = GetGuests(users);
        modelBuilder.Entity<Guest>().HasData(guests);

        var hosts = GetHosts(users);
        modelBuilder.Entity<Host>().HasData(hosts);

        var properties = GetProperties(hosts);
        modelBuilder.Entity<Property>().HasData(properties);

        if (GetPropertyImages(properties, out var propertyImages)) return;
        modelBuilder.Entity<PropertyImage>().HasData(propertyImages);

        var bookings = GetBookings(properties, users);
        modelBuilder.Entity<Booking>().HasData(bookings);
        var propertyUtilities = GetPropertyUtility();
        modelBuilder.Entity<PropertyUtility>().HasData(propertyUtilities);

        var guestReviews = GetGuestReviews(guests, hosts);
        modelBuilder.Entity<GuestReview>().HasData(guestReviews);

        var hostReviews = GetHostReviews(hosts, guests);
        modelBuilder.Entity<HostReview>().HasData(hostReviews);

        var propertyReviews = GetPropertyReviews(properties, guests);
        modelBuilder.Entity<PropertyReview>().HasData(propertyReviews);
    }

    private static List<PropertyReview> GetPropertyReviews(List<Property> properties,
                                                           List<Guest> guests)
    {
        return new Faker<PropertyReview>()
            .RuleFor(b => b.PropertyId, f => f.PickRandom(properties).Id)
            .RuleFor(b => b.GuestId, f => f.PickRandom(guests).Id)
            .RuleFor(b => b.Content, f => f.Lorem.Paragraph())
            .RuleFor(b => b.Cleanliness, f => f.Random.Int(1, 5))
            .RuleFor(b => b.Communication, f => f.Random.Int(1, 5))
            .RuleFor(b => b.CheckIn, f => f.Random.Int(1, 5))
            .RuleFor(b => b.Accuracy, f => f.Random.Int(1, 5))
            .RuleFor(b => b.Location, f => f.Random.Int(1, 5))
            .RuleFor(b => b.Value, f => f.Random.Int(1, 5))
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.CreatedAt, f => f.Date.Past())
            .Generate(500);
    }

    private static List<HostReview> GetHostReviews(List<Host> hosts,
                                                   List<Guest> guests)
    {
        return new Faker<HostReview>()
            .RuleFor(b => b.HostId, f => f.PickRandom(hosts).Id)
            .RuleFor(b => b.GuestId, f => f.PickRandom(guests).Id)
            .RuleFor(b => b.Content, f => f.Lorem.Paragraph())
            .RuleFor(b => b.Rating, f => f.Random.Int(1, 5))
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.CreatedAt, f => f.Date.Past())
            .Generate(300);
    }

    private static List<GuestReview> GetGuestReviews(List<Guest> guests,
                                                     List<Host> hosts)
    {
        return new Faker<GuestReview>()
            .RuleFor(b => b.GuestId, f => f.PickRandom(guests).Id)
            .RuleFor(b => b.HostId, f => f.PickRandom(hosts).Id)
            .RuleFor(b => b.Content, f => f.Lorem.Paragraph())
            .RuleFor(b => b.Rating, f => f.Random.Int(1, 5))
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.CreatedAt, f => f.Date.Past())
            .Generate(300);
    }

    private static List<Booking> GetBookings(List<Property> properties,
                                             List<User> users)
    {
        return new Faker<Booking>()
            .RuleFor(b => b.CleaningFee, f => f.Random.Double(10, 25))
            .RuleFor(b => b.PricePerNight, f => f.Random.Double(10, 100))
            .RuleFor(b => b.PropertyId, f => f.PickRandom(properties).Id)
            .RuleFor(b => b.SystemFee, f => f.Random.Double(10, 25))
            .RuleFor(b => b.CheckInDate,
                f => f.Date.Between(DateTime.UtcNow.AddYears(-1), DateTime.UtcNow.AddYears(1)).Date)
            .RuleFor(b => b.CheckOutDate, (f,
                                           b) => b.CheckInDate.AddDays(f.Random.Number(1, 10)).Date)
            .RuleFor(b => b.TotalPrice, (_,
                                         b) => b.PricePerNight * (b.CheckOutDate - b.CheckInDate).Days + b.CleaningFee +
                                               b.SystemFee)
            .RuleFor(b => b.Note, f => f.Lorem.Sentence())
            .RuleFor(b => b.NumberOfAdults, f => f.Random.Number(1, 5))
            .RuleFor(b => b.NumberOfChildren, f => f.Random.Number(0, 5))
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.CancellationPolicyType, f => f.PickRandom<CancellationPolicyType>())
            .RuleFor(b => b.Status, (f,
                                     b) => b.CheckOutDate < DateTime.UtcNow
                                               ? BookingStatus.Completed
                                               : f.PickRandom<BookingStatus>())
            .RuleFor(b => b.GuestId, f => f.PickRandom(users).Id)
            .Generate(500);
    }

    private static bool GetPropertyImages(List<Property> properties,
                                          out List<PropertyImage> propertyImages)
    {
        List<FakePropertyImgUrl> fakePropertyImgUrls;
        propertyImages = new List<PropertyImage>();
        try
        {
            fakePropertyImgUrls = JsonSerializer.Deserialize<List<FakePropertyImgUrl>>(
                                      File.ReadAllText("../AirCnC.Infrastructure/data.json"))
                                  ?? throw new Exception("Seed data file not found");
        }
        catch
        {
            return true;
        }

        var indexFakePropertyImgUrl = 0;
        var indexPropertyImg = 0;
        foreach (var property in properties)
        {
            foreach (var url in fakePropertyImgUrls[indexFakePropertyImgUrl].urlImgs!)
            {
                propertyImages.Add(new PropertyImage
                {
                    Id = indexPropertyImg + 1,
                    PropertyId = property.Id,
                    Url = url
                });
                indexPropertyImg++;
            }

            indexFakePropertyImgUrl++;
        }

        return false;
    }

    private static List<Guest> GetGuests(List<User> users)
    {
        return users.Select(u => new Guest
        {
            Id = u.Id,
            UserId = u.Id,
            CreatedAt = new Faker().Date.Past(),
        }).ToList();
    }

    private static List<Host> GetHosts(List<User> users)
    {
        var hostUsers = users.ToList();
        var hosts = new Faker<Host>()
            .RuleFor(h => h.UserId, f =>
            {
                var user = f.PickRandom(hostUsers);
                hostUsers.Remove(user);
                return user.Id;
            })
            .RuleFor(h => h.Id, f => f.IndexFaker + 1)
            .RuleFor(h => h.CreatedAt, f => f.Date.Past())
            .Generate(20);
        return hosts;
    }

    private static List<Property> GetProperties(List<Host> hosts)
    {
        return new Faker<Property>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.HostId, f => f.PickRandom(hosts).Id)
            .RuleFor(p => p.Type, f => f.PickRandom<PropertyType>())
            .RuleFor(p => p.BedCount, f => f.Random.Number(1, 5))
            .RuleFor(p => p.BedroomCount, f => f.Random.Number(1, 8))
            .RuleFor(p => p.BathroomCount, f => f.Random.Number(1, 3))
            .RuleFor(p => p.MaxAdultCount, f => f.Random.Number(1, 10))
            .RuleFor(p => p.MaxChildCount, f => f.Random.Number(1, 10))
            .RuleFor(p => p.Title, f => f.Lorem.Sentence(3, 7))
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            // Generate a random location in VietNam
            .RuleFor(p => p.Latitude, f => f.Address.Latitude(8.59975962975, 23.3933950367))
            .RuleFor(p => p.Longitude, f => f.Address.Longitude(102.170435826, 109.33526981))
            .RuleFor(p => p.Address, f => f.Address.StreetAddress())
            // Generate a random city in VietNam
            .RuleFor(p => p.City, f => f.PickRandom(GetAllProvince()))
            .RuleFor(p => p.CancellationPolicyType, f => f.PickRandom<CancellationPolicyType>())
            .RuleFor(p => p.PricePerNight, f => f.Random.Int(100, 50000) * 1000)
            .RuleFor(p => p.CleaningFee, f => f.Random.Int(30, 350) * 1000)
            .RuleFor(p => p.Status, f => f.PickRandom<PropertyStatus>())
            .Generate(100);
    }

    private static List<User> GetUsers()
    {
        return new Faker<User>()
            // admin co id = 1 nen o day la 2
            .RuleFor(u => u.Id, f => f.IndexFaker + 2)
            .RuleFor(u => u.FullName, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.NormalizedEmail, (_,
                                              u) => u.Email?.ToUpper())
            .RuleFor(u => u.UserName, (_,
                                       u) => u.Email)
            .RuleFor(u => u.NormalizedUserName, (_,
                                                 u) => u.UserName?.ToUpper())
            .RuleFor(u => u.Address, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Introduction, f => f.Lorem.Paragraph())
            .RuleFor(u => u.AvatarUrl, f => f.Image.PicsumUrl())
            .RuleFor(u => u.EmailConfirmed, _ => true)
            .RuleFor(u => u.SecurityStamp, _ => Guid.NewGuid().ToString())
            .RuleFor(u => u.PasswordHash, _ => new PasswordHasher<User>().HashPassword(null!, "User@123"))
            .Generate(100);
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

    private static List<PropertyUtility> GetPropertyUtility()
    {
        return new Faker<PropertyUtility>()
            .RuleFor(pu => pu.Id, f => f.IndexFaker + 1)
            .RuleFor(pu => pu.IsAirConditioning, f => f.Random.Bool())
            .RuleFor(pu => pu.IsWifi, f => f.Random.Bool())
            .RuleFor(pu => pu.IsTv, f => f.Random.Bool())
            .RuleFor(pu => pu.IsKitchen, f => f.Random.Bool())
            .RuleFor(pu => pu.IsAirConditioning, f => f.Random.Bool())
            .RuleFor(pu => pu.IsLaptopFriendlyWorkspace, f => f.Random.Bool())
            .RuleFor(pu => pu.IsHotWater, f => f.Random.Bool())
            .RuleFor(pu => pu.IsBreakfast, f => f.Random.Bool())
            .RuleFor(pu => pu.IsRoomService, f => f.Random.Bool())
            .RuleFor(pu => pu.IsBar, f => f.Random.Bool())
            .RuleFor(pu => pu.IsSwimmingPool, f => f.Random.Bool())
            .RuleFor(pu => pu.IsGym, f => f.Random.Bool())
            .RuleFor(pu => pu.IsSpa, f => f.Random.Bool())
            .RuleFor(pu => pu.IsBeachFront, f => f.Random.Bool())
            .RuleFor(pu => pu.IsMountainView, f => f.Random.Bool())
            .RuleFor(pu => pu.IsLakeView, f => f.Random.Bool())
            .RuleFor(pu => pu.IsSeaView, f => f.Random.Bool())
            .RuleFor(pu => pu.IsLandmarkView, f => f.Random.Bool())
            .RuleFor(pu => pu.IsWheelchairAccessible, f => f.Random.Bool())
            .RuleFor(pu => pu.IsElevator, f => f.Random.Bool())
            .RuleFor(pu => pu.IsSecurityCamera, f => f.Random.Bool())
            .RuleFor(pu => pu.IsCamperFriendly, f => f.Random.Bool())
            .RuleFor(pu => pu.PropertyId, f => f.IndexFaker + 1)
            .Generate(100);
    }

    private static List<string> GetAllProvince()
    {
        return new List<string>()
        {
            "Hồ Chí Minh",
            "An Giang",
            "Bà Rịa - Vũng Tàu",
            "Bắc Giang",
            "Bắc Kạn",
            "Bạc Liêu",
            "Bắc Ninh",
            "Bến Tre",
            "Bình Định",
            "Bình Dương",
            "Bình Phước",
            "Bình Thuận",
            "Cà Mau",
            "Cao Bằng",
            "Đắk Lắk",
            "Đắk Nông",
            "Điện Biên",
            "Đồng Nai",
            "Đồng Tháp",
            "Gia Lai",
            "Hà Giang",
            "Hà Nam",
            "Hà Tĩnh",
            "Hải Dương",
            "Hậu Giang",
            "Hòa Bình",
            "Hưng Yên",
            "Khánh Hòa",
            "Kiên Giang",
            "Kon Tum",
            "Lai Châu",
            "Lâm Đồng",
            "Lạng Sơn",
            "Lào Cai",
            "Long An",
            "Nam Định",
            "Nghệ An",
            "Ninh Bình",
            "Ninh Thuận",
            "Phú Thọ",
            "Quảng Bình",
            "Quảng Nam",
            "Quảng Ngãi",
            "Quảng Ninh",
            "Quảng Trị",
            "Sóc Trăng",
            "Sơn La",
            "Tây Ninh",
            "Thái Bình",
            "Thái Nguyên",
            "Thanh Hóa",
            "Thừa Thiên Huế",
            "Tiền Giang",
            "Trà Vinh",
            "Tuyên Quang",
            "Vĩnh Long",
            "Vĩnh Phúc",
            "Yên Bái",
            "Phú Yên",
            "Cần Thơ",
            "Đà Nẵng",
            "Hải Phòng",
            "Hà Nội",
        };
    }
}