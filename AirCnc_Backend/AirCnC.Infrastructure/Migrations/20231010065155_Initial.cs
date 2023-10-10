using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirCnC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    State = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestReviews_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GuestReviews_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HostReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostReviews_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HostReviews_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AccountHolder = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentInfos_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedCount = table.Column<int>(type: "int", nullable: false),
                    BedroomCount = table.Column<int>(type: "int", nullable: false),
                    BathroomCount = table.Column<int>(type: "int", nullable: false),
                    MaxAdultCount = table.Column<int>(type: "int", nullable: false),
                    MaxChildCount = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Latitude = table.Column<double>(type: "float(13)", precision: 13, scale: 10, nullable: false),
                    Longitude = table.Column<double>(type: "float(13)", precision: 13, scale: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    CleaningFee = table.Column<double>(type: "float", nullable: false),
                    CancellationPolicyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    CleaningFee = table.Column<double>(type: "float", nullable: false),
                    SystemFee = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CancellationPolicyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationTicketId = table.Column<int>(type: "int", nullable: true),
                    BookingPaymentId = table.Column<int>(type: "int", nullable: true),
                    HostPaymentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsWifi = table.Column<bool>(type: "bit", nullable: false),
                    IsTv = table.Column<bool>(type: "bit", nullable: false),
                    IsKitchen = table.Column<bool>(type: "bit", nullable: false),
                    IsAirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    IsLaptopFriendlyWorkspace = table.Column<bool>(type: "bit", nullable: false),
                    IsHotWater = table.Column<bool>(type: "bit", nullable: false),
                    IsBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    IsRoomService = table.Column<bool>(type: "bit", nullable: false),
                    IsBar = table.Column<bool>(type: "bit", nullable: false),
                    IsSwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    IsGym = table.Column<bool>(type: "bit", nullable: false),
                    IsSpa = table.Column<bool>(type: "bit", nullable: false),
                    IsBeachFront = table.Column<bool>(type: "bit", nullable: false),
                    IsMountainView = table.Column<bool>(type: "bit", nullable: false),
                    IsLakeView = table.Column<bool>(type: "bit", nullable: false),
                    IsSeaView = table.Column<bool>(type: "bit", nullable: false),
                    IsLandmarkView = table.Column<bool>(type: "bit", nullable: false),
                    IsWheelchairAccessible = table.Column<bool>(type: "bit", nullable: false),
                    IsElevator = table.Column<bool>(type: "bit", nullable: false),
                    IsSecurityCamera = table.Column<bool>(type: "bit", nullable: false),
                    IsCamperFriendly = table.Column<bool>(type: "bit", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyAmenities_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    Cleanliness = table.Column<int>(type: "int", nullable: false),
                    Communication = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyReviews_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyReviews_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wishlists_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CancellationTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    TheOtherPartyId = table.Column<int>(type: "int", nullable: false),
                    IsIssuerGuest = table.Column<bool>(type: "bit", nullable: false),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationReasonNote = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolveNote = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    RefundAmount = table.Column<double>(type: "float", nullable: false),
                    ChargeAmount = table.Column<double>(type: "float", nullable: false),
                    RefundPaymentId = table.Column<int>(type: "int", nullable: true),
                    ChargePaymentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancellationTickets_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HostPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentInfoId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostPayments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HostPayments_PaymentInfos_PaymentInfoId",
                        column: x => x.PaymentInfoId,
                        principalTable: "PaymentInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancellationTicketAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CancellationTicketId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationTicketAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CancellationTicketAttachments_CancellationTickets_CancellationTicketId",
                        column: x => x.CancellationTicketId,
                        principalTable: "CancellationTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChargePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BookingPaymentCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false),
                    CancellationTicketId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargePayments_CancellationTickets_CancellationTicketId",
                        column: x => x.CancellationTicketId,
                        principalTable: "CancellationTickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChargePayments_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefundPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BookingPaymentCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    CancellationTicketId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundPayments_CancellationTickets_CancellationTicketId",
                        column: x => x.CancellationTicketId,
                        principalTable: "CancellationTickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RefundPayments_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FullName", "Introduction", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, null, null, "71eee8c1-7b46-4d1f-a861-ca99027dafd5", null, "admin@gmail.com", true, "Phuc Phan", null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEH6bDu+JdvurpnNB7kXNooRAzOhqzt6gMoI/25Zw9yAS88u8D94YJY3HK8gLTL4eLA==", null, false, "95ed4a99-2330-46b9-96bc-af63fb483e90", null, false, "admin" },
                    { 2, 0, null, null, null, "a156c1af-6d5a-4e88-8774-ecf1dcea76fe", null, "Arno.Brekke41@hotmail.com", false, "Rita Crona", null, false, null, "ARNO.BREKKE41@HOTMAIL.COM", "ARNO.BREKKE41@HOTMAIL.COM", "AQAAAAIAAYagAAAAEDu82yYQJ4mYleqazJH7vAHUeHbypbW7dIu5krK9XhLAXBDjxMqxLWh81t0H9Bxiow==", null, false, "152f5b54-2e0a-42b4-99b9-ce87fc2a3c71", null, false, "Arno.Brekke41@hotmail.com" },
                    { 3, 0, null, null, null, "2852ad87-dc76-4fb0-b8a2-f9bf01c7df15", null, "Desiree_Sporer@yahoo.com", false, "Hans Corkery", null, false, null, "DESIREE_SPORER@YAHOO.COM", "DESIREE_SPORER@YAHOO.COM", "AQAAAAIAAYagAAAAEPdylSEeqrbeiW0eIITpz++zmIq9ZCkHI+IcPHduUxtlYYOAVLzm7GBiUB5D8TVxeQ==", null, false, "bc0a278a-49e3-4c10-8e25-fce425854f21", null, false, "Desiree_Sporer@yahoo.com" },
                    { 4, 0, null, null, null, "23193404-b23c-43d5-a9fe-920ec6b1b89e", null, "River.Stiedemann@hotmail.com", false, "Beaulah Littel", null, false, null, "RIVER.STIEDEMANN@HOTMAIL.COM", "RIVER.STIEDEMANN@HOTMAIL.COM", "AQAAAAIAAYagAAAAEKAGchq1jVy1J+AwUScW2Uj8ZtM3QW97GoPvSbb4iOWaSsTLk2D0Dz+M0MBvU6rayw==", null, false, "cf652446-a7ab-4fc5-9a92-8a70374b14a7", null, false, "River.Stiedemann@hotmail.com" },
                    { 5, 0, null, null, null, "3f4c0e5b-ce6a-4b8e-a1d9-8f5624f0afd1", null, "Greyson.Gislason@yahoo.com", false, "Dawson McKenzie", null, false, null, "GREYSON.GISLASON@YAHOO.COM", "GREYSON.GISLASON@YAHOO.COM", "AQAAAAIAAYagAAAAELYsZ/4lyiMiy+8jy4iIsSLZlZ8//008XGg8M9xJn/oNkeMacNpkZV4wMftbuQKsvQ==", null, false, "4349629a-8d3f-4cec-88b6-d81ac58d4891", null, false, "Greyson.Gislason@yahoo.com" },
                    { 6, 0, null, null, null, "a9aedd88-0ea5-4283-8692-f1774ccb089f", null, "Virgil.McCullough11@hotmail.com", false, "Barrett Feest", null, false, null, "VIRGIL.MCCULLOUGH11@HOTMAIL.COM", "VIRGIL.MCCULLOUGH11@HOTMAIL.COM", "AQAAAAIAAYagAAAAEFtwB5iuGy+s5L+mSEqvtUcNbO8oVQBRIGeqJHp9QT9/FTfd5IFkrpWvVTt7Aggiiw==", null, false, "56859fd3-825a-4ff6-a611-85a4fe734b20", null, false, "Virgil.McCullough11@hotmail.com" },
                    { 7, 0, null, null, null, "ab8c990d-514c-4043-8e85-543b9be8fbbb", null, "Myrtie92@yahoo.com", false, "Jazmyne Kuvalis", null, false, null, "MYRTIE92@YAHOO.COM", "MYRTIE92@YAHOO.COM", "AQAAAAIAAYagAAAAENKBhARL9td1WCJTmgKqNAtZLkRXxFXkjzvVvwcD/7bOmSK4rLvxU+UGIvd4kJp7mw==", null, false, "4129e168-fc29-4bea-98dc-be2dea7ee568", null, false, "Myrtie92@yahoo.com" },
                    { 8, 0, null, null, null, "0ef81fac-629e-43fd-ba1f-cc32d58c9d03", null, "Ramon.Hayes9@yahoo.com", false, "Alexanne Braun", null, false, null, "RAMON.HAYES9@YAHOO.COM", "RAMON.HAYES9@YAHOO.COM", "AQAAAAIAAYagAAAAEOm/ogpqsGyHEeFowPe0jAJdJPbTbb3HgezGLQV0iRQ7Rt3xp+yUyVhXaIIohRzu0g==", null, false, "bc257947-bf2a-4d96-9fab-8ec82b25983b", null, false, "Ramon.Hayes9@yahoo.com" },
                    { 9, 0, null, null, null, "079616ce-0eda-40a5-a7dd-8e57bf25ecc7", null, "Eddie6@hotmail.com", false, "Bernie Koepp", null, false, null, "EDDIE6@HOTMAIL.COM", "EDDIE6@HOTMAIL.COM", "AQAAAAIAAYagAAAAENJCAO8pGB+bW5MoG8dRRD9aqGP7TniKYzMmXbfZ+s1Rl+1zGTROSIA/wVAsoBSP/A==", null, false, "5403d76f-d600-4291-b59a-b9f014d9daac", null, false, "Eddie6@hotmail.com" },
                    { 10, 0, null, null, null, "a14e87c6-ecf2-400d-92a1-2f01066e2eb9", null, "Jesse.Homenick60@hotmail.com", false, "Josefina Johns", null, false, null, "JESSE.HOMENICK60@HOTMAIL.COM", "JESSE.HOMENICK60@HOTMAIL.COM", "AQAAAAIAAYagAAAAEH7gXuCQB1FPOVp+tTkKq7ibhoHaI1l+rQN/o9p3yWXub/7J9C1aV24ZQbgURG4cTQ==", null, false, "d7a7efec-7e0e-4a01-b822-9b8f4da988e7", null, false, "Jesse.Homenick60@hotmail.com" },
                    { 11, 0, null, null, null, "2a754d05-d8d6-406d-89d9-bd5345893d73", null, "Domenic.Ruecker91@hotmail.com", false, "Frederique McGlynn", null, false, null, "DOMENIC.RUECKER91@HOTMAIL.COM", "DOMENIC.RUECKER91@HOTMAIL.COM", "AQAAAAIAAYagAAAAEGfSRfHY2R0qhJzG9Vd1zv3CDpoQBJz9GXobbk9zwjW/qzdFic8BExJkdnVpDCBjog==", null, false, "e3114512-8187-495f-8343-0366e2acf88e", null, false, "Domenic.Ruecker91@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsBlocked", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 4 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 5 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 6 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 7 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 8 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 9 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 10 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 11 }
                });

            migrationBuilder.InsertData(
                table: "Hosts",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsBlocked", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 3 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 10 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 11 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 8 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "BathroomCount", "BedCount", "BedroomCount", "CancellationPolicyType", "City", "CleaningFee", "CreatedAt", "CreatedBy", "Description", "HostId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Latitude", "Longitude", "MaxAdultCount", "MaxChildCount", "PricePerNight", "RejectionReason", "Status", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "120 Manley Mountain", 3, 1, 8, "Strict", "North Kane", 87.513819910974277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Assumenda sequi veniam atque. Et vitae quod tenetur. Hic dolore qui id tempora et omnis provident sint sed. Accusamus dignissimos qui fugit facilis voluptatem occaecati natus. Facere libero quis ipsum qui enim et quibusdam. Fugiat nemo ut dolorem optio optio ut modi expedita.", 1, false, null, null, 86.078999999999994, -10.7479, 9, 8, 48.899815345386713, null, 1, "Et ea temporibus ea et sint est sit assumenda omnis provident illo perferendis debitis veritatis dolorem.", "Hotel" },
                    { 2, "2689 Jessyca Extension", 1, 1, 7, "Strict", "New Rosalyn", 44.387251989586453, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Occaecati quo delectus accusamus sint laudantium optio animi consequatur. Quis dolores dolores quae modi nihil beatae. Doloribus vel commodi aut ut.", 4, false, null, null, 89.091200000000001, -109.8887, 8, 6, 85.866997439007903, null, 1, "Voluptate enim qui a expedita adipisci alias veniam quidem itaque tenetur.", "Hotel" },
                    { 3, "7746 Quigley Bridge", 1, 4, 4, "Flexible", "Eltaside", 75.138478591145955, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nulla est ab. Nemo eaque laudantium natus vel. Quia enim quo magni dolorem.", 3, false, null, null, 82.780500000000004, -160.49719999999999, 3, 10, 34.687555540226157, null, 2, "Et voluptatibus eum nobis optio voluptas repellat quod velit temporibus odio voluptatem beatae ipsa mollitia ipsa placeat doloribus modi minima quis quod pariatur natus voluptatum atque.", "Hotel" },
                    { 4, "0691 Eden Freeway", 2, 4, 2, "Flexible", "Kassulkeshire", 61.337688850365936, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ex non recusandae rem recusandae et animi sint. Explicabo sint vero iste nam. Delectus sunt dolorem minima et ut.", 2, false, null, null, 6.9454000000000002, -139.99889999999999, 5, 6, 79.284632790974158, null, 1, "At est consequatur soluta odit modi sit id dolor provident recusandae deserunt suscipit exercitationem cumque maxime eum voluptatem assumenda error.", "Apartment" },
                    { 5, "691 Julie Prairie", 2, 5, 7, "Flexible", "DuBuqueton", 58.517188002228245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sit sapiente reprehenderit officiis ut nisi perspiciatis voluptatem consectetur molestiae. Minima quia praesentium adipisci. Nemo vel molestiae eum magni nisi sed sed. Maiores quibusdam explicabo voluptates quia aut vel laboriosam provident.", 4, false, null, null, -30.600100000000001, 88.123400000000004, 6, 7, 40.761607559343638, null, 3, "Earum enim consequatur non velit quae reprehenderit dolor ipsa tempora hic et non laborum ea dolor omnis vel.", "Resort" },
                    { 6, "1799 Mariah Oval", 2, 1, 2, "Flexible", "Vandervortstad", 12.193588442323486, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Qui deserunt ut. Rerum quae ut perspiciatis similique. Vitae voluptas similique repellat similique laboriosam nesciunt quidem. Quam commodi iure laboriosam et distinctio iusto consequatur possimus.", 5, false, null, null, -47.648000000000003, 32.325600000000001, 1, 9, 63.709213968076256, null, 1, "Dolorum quam dicta sint suscipit nihil soluta aut nostrum laborum eius repellendus sit vitae at quo unde.", "House" },
                    { 7, "2049 MacGyver Drive", 1, 5, 3, "Flexible", "Lake Freddy", 29.97155228652608, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Distinctio asperiores maxime quaerat quisquam amet et enim consequatur. Et sit voluptatem. Autem fuga qui quidem pariatur id qui nihil quos. Culpa sed recusandae dolorem quia. Qui qui eligendi non blanditiis sequi odit sequi totam. Voluptate dolorem alias enim natus occaecati aut corrupti.", 3, false, null, null, 13.4871, -132.35140000000001, 4, 2, 98.049142449730965, null, 2, "Aliquid iste debitis quibusdam et provident quae non minima accusamus et sunt rem qui minima commodi dignissimos sapiente nisi libero voluptatibus aut ullam.", "Villa" },
                    { 8, "903 Towne Stravenue", 2, 2, 3, "Strict", "New Kobyborough", 93.508468639767202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Molestiae quaerat similique temporibus. Doloremque iste eos molestiae veniam est. Iusto magnam veritatis voluptatum totam laudantium rerum. Explicabo veniam aut quia. Quae nulla dicta quo voluptatum cumque molestias vero dolore.", 5, false, null, null, 42.939900000000002, 85.103700000000003, 2, 7, 44.037760602556681, null, 2, "Debitis non reiciendis excepturi iusto dolor ab repellat debitis voluptatum accusamus maxime dolores.", "Villa" },
                    { 9, "699 Little Village", 1, 5, 6, "Strict", "Port Gardnerfurt", 90.501629914842084, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Labore fugit et nostrum. Sed occaecati quasi et provident sit voluptates soluta non. Sed accusamus id. Velit iure et voluptates sint voluptatem fugiat iusto ab. Ut omnis laborum dolorum quasi aut rerum.", 2, false, null, null, 24.169599999999999, 157.0292, 8, 7, 77.191617666203655, null, 1, "Enim amet nisi itaque minima reiciendis reiciendis a recusandae asperiores qui aliquam et odit aut.", "House" },
                    { 10, "6139 Elias Underpass", 3, 1, 3, "Strict", "Schmelermouth", 89.182367342926625, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sunt debitis amet et suscipit similique quibusdam. Eius voluptatibus quasi accusantium beatae similique tempora corrupti. Ipsa impedit perferendis veritatis autem ea.", 5, false, null, null, -74.728800000000007, -42.692799999999998, 8, 5, 94.741500746364636, null, 2, "Blanditiis minus laboriosam non et fugit fugiat consequatur veniam similique eligendi nihil libero autem tempore exercitationem quidem ut perspiciatis.", "Hotel" },
                    { 11, "3160 Alfredo Alley", 1, 2, 4, "Strict", "Hilpertshire", 96.659199622675061, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doloribus nihil facere eum sint ab excepturi corporis vero. Reprehenderit illo quam enim in adipisci. Et voluptates ut voluptas sint consequuntur ratione. Deleniti est quia molestiae. Enim exercitationem praesentium dignissimos.", 1, false, null, null, 8.8491999999999997, -82.793199999999999, 1, 9, 74.126424981775983, null, 3, "Quia earum excepturi temporibus repudiandae repellat iste ipsam dolorum dolor sit et ex officiis sapiente reprehenderit consectetur deleniti atque soluta voluptatem voluptatem adipisci eveniet dolor.", "House" },
                    { 12, "81086 Tremayne Center", 1, 1, 1, "Flexible", "McKenzieburgh", 91.600665767013879, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dolor ut illo et cum velit eos perferendis enim qui. Mollitia dolor ipsam nobis aliquid dolore sunt et quae laudantium. Id assumenda nesciunt nihil ut fuga eaque. Occaecati aut dolorum est praesentium distinctio dolorem nihil. Illo vel ducimus esse perspiciatis ea.", 4, false, null, null, -59.123899999999999, 111.70829999999999, 6, 9, 32.802619573917859, null, 2, "Iure est mollitia omnis totam ut quam dolor quia cumque nihil non quidem nihil est debitis et a ipsum officia aut quisquam earum voluptatibus beatae magni magnam earum dolorem.", "House" },
                    { 13, "400 Emmerich Mountain", 1, 5, 4, "Flexible", "East Wyatt", 64.359550898828871, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sit cum repellat iure aut nobis. Et repellendus ut. Qui nam sed qui dolore nobis animi quia eligendi. Qui et molestiae aut.", 1, false, null, null, -68.796599999999998, -51.352499999999999, 1, 4, 19.173717894847179, null, 1, "Alias laborum aspernatur dolorem quas repellendus rerum qui vel non nemo.", "HomeStay" },
                    { 14, "080 Wilfred Squares", 1, 2, 4, "Strict", "Nikolausview", 37.530064129390695, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Et nihil adipisci aliquam aut. Et ut at officia expedita. Voluptatum sint est voluptatum modi rerum facere numquam dolorum laudantium.", 5, false, null, null, -76.627399999999994, 124.87179999999999, 7, 1, 37.591198659026276, null, 1, "Dolorum repudiandae quos ab voluptas aut rem labore et cum consequatur et consectetur mollitia a debitis aut ut ut enim hic.", "Room" },
                    { 15, "813 Maddison Rapids", 2, 3, 7, "Strict", "Jerrodchester", 14.932614346757342, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Amet reiciendis unde ut aliquam atque odio. Id quia error ratione ut molestias quo. Ea est quos omnis saepe quia vitae.", 3, false, null, null, 18.3611, -123.93259999999999, 8, 3, 26.046608642548634, null, 1, "Omnis dolorem asperiores explicabo earum nobis reprehenderit aut quia et et dolores repellendus illo aliquid ipsa vitae nihil molestias voluptas aut.", "HomeStay" },
                    { 16, "9397 Moen Mall", 2, 1, 2, "Flexible", "Edwinaview", 90.753765284675808, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Qui ipsam omnis quia fugiat officiis ut. Est consequatur qui eveniet. Ut voluptatem asperiores magni. Accusamus quia illum ut aut. Mollitia repellendus et cupiditate est.", 1, false, null, null, -14.516400000000001, 170.19550000000001, 3, 3, 54.021694058494589, null, 3, "Magni sit facere et a aut et doloribus et voluptatem quae itaque quas velit in aliquid quisquam sit ab quibusdam expedita consequuntur vitae aut voluptatum amet et.", "HomeStay" },
                    { 17, "1419 Alex Manor", 1, 3, 8, "Strict", "Bodemouth", 14.424952869961821, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Incidunt sunt deserunt quaerat sit qui. Odit quos nulla. Quo doloribus repudiandae nostrum illo sint. Aut a harum inventore. Itaque sunt sed doloribus alias ut minus laudantium.", 1, false, null, null, -84.545100000000005, 65.446700000000007, 2, 1, 31.608366212439105, null, 2, "Doloribus ut voluptas aut ipsam magnam corrupti culpa ab tempora reprehenderit doloribus assumenda quibusdam distinctio rerum recusandae possimus eaque ex doloremque et assumenda odio dolorem magnam cupiditate consequatur doloremque.", "HomeStay" },
                    { 18, "46258 Clemmie Ville", 2, 5, 3, "Flexible", "Mullerberg", 51.237712893592104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Et ipsum aperiam. Nesciunt eveniet et optio dolorem est aut veritatis et totam. Aliquam tempore quia.", 5, false, null, null, -42.281799999999997, -26.8551, 8, 2, 99.172206130759179, null, 1, "Recusandae sed earum eum maiores error et ut ullam vitae iure voluptas nemo molestiae nihil quaerat doloribus cupiditate velit nisi voluptas rem necessitatibus illum nisi molestiae voluptas cumque autem.", "Apartment" },
                    { 19, "1736 Tromp Islands", 3, 4, 1, "Flexible", "West Fannie", 32.531080646283783, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eius officia neque. Est ratione aut quaerat nam illum odit. Itaque et accusamus provident commodi.", 3, false, null, null, -89.254199999999997, -120.2253, 6, 1, 15.317213281514501, null, 2, "Enim earum iste voluptatem veritatis ipsa odio sit voluptatibus cumque autem aliquid perferendis voluptas rerum quis.", "Apartment" },
                    { 20, "0829 Dino Fort", 2, 3, 1, "Strict", "West Elena", 28.59039439282903, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quasi sint impedit reiciendis. Placeat eum magnam error autem eveniet animi. Est voluptatibus minima iste est veniam aut. Dolores blanditiis iure. Debitis praesentium tempore consectetur dolor aut.", 2, false, null, null, -71.018000000000001, 156.08670000000001, 6, 5, 94.136570609080962, null, 3, "Quia deserunt praesentium repellendus voluptatem quasi esse iste doloribus natus autem voluptatibus similique eos est velit nemo nulla ut minima quae perspiciatis corrupti fugit maxime nobis aut at.", "Resort" },
                    { 21, "124 Renee Road", 2, 4, 2, "Strict", "Lake Barryshire", 24.358742294762955, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Debitis nulla nihil enim nostrum. Quam voluptatem error omnis. Fugiat suscipit consequatur sit nam ipsum ut excepturi. Velit quia sunt dolores dicta assumenda deleniti iste deserunt. Ut distinctio ut ut praesentium excepturi maxime rerum.", 4, false, null, null, -86.148899999999998, 168.53149999999999, 7, 8, 80.564933045958028, null, 2, "Enim autem commodi ipsum nihil corrupti et eaque sunt quidem maxime voluptate libero commodi saepe molestiae voluptate est fugiat rerum blanditiis repellendus corrupti distinctio quibusdam pariatur hic sint molestias quis.", "Resort" },
                    { 22, "36636 Satterfield Freeway", 3, 3, 8, "Strict", "Zboncakfort", 73.940650855073699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adipisci explicabo quis minus suscipit et quaerat aut dolorem sit. Ducimus dolore repellat ut animi. Qui consequatur quos adipisci sed. Non rerum officiis odio aliquid porro commodi quos quae ipsa. Molestias qui sequi reprehenderit. Culpa cumque ut perspiciatis.", 2, false, null, null, 34.0092, 67.573599999999999, 1, 10, 25.334926327380508, null, 2, "Ut voluptas eos sit velit unde voluptatibus corrupti et vel in dolore reprehenderit quibusdam voluptas mollitia.", "Apartment" },
                    { 23, "91290 Zemlak Route", 3, 5, 4, "Flexible", "Bahringerburgh", 76.628997174473412, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Excepturi quia in omnis et quae quidem. Consequatur est earum delectus ullam dolore. Similique ad consequatur quia eveniet exercitationem enim vitae.", 1, false, null, null, -4.1737000000000002, -54.512999999999998, 6, 8, 88.628086854404017, null, 2, "Et culpa possimus et assumenda doloribus quidem aut quia soluta facilis a veniam ratione blanditiis est sequi asperiores dolores aut enim possimus sequi odio qui necessitatibus.", "HomeStay" },
                    { 24, "336 Adan Village", 2, 4, 5, "Strict", "West Brookchester", 52.105833104511909, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Voluptatum eius praesentium voluptates. Fugiat velit qui delectus nisi sed enim illo. Error consequatur aliquid dolore enim et et distinctio exercitationem. Ut voluptate quasi ipsum aut vel.", 4, false, null, null, -1.6524000000000001, 1.0888, 5, 7, 21.248103572643188, null, 1, "Sapiente molestiae ut aliquid eum deserunt temporibus voluptatem assumenda iusto minima temporibus delectus aperiam.", "Villa" },
                    { 25, "8055 Wilderman Parkway", 2, 3, 7, "Flexible", "Borerberg", 17.469541165763811, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Recusandae dolorem non optio necessitatibus ab quaerat autem mollitia temporibus. Et eum quasi quibusdam odio omnis. Esse deleniti rerum. Blanditiis minima assumenda et eius ut dolorem voluptatibus necessitatibus totam. Quia aut qui.", 1, false, null, null, -7.3928000000000003, -174.51519999999999, 5, 6, 21.726182831949053, null, 1, "Voluptate delectus velit dolor iusto consequatur tenetur dolor laudantium minima velit aliquam quo illo ducimus officiis maiores ipsum iste vel error voluptatem blanditiis.", "HomeStay" },
                    { 26, "00345 William Center", 2, 5, 4, "Strict", "Halvorsonland", 16.812034673591199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Architecto et quisquam fugiat voluptas vel sit sapiente. Corporis veniam rem sit est doloribus laudantium. Est magni ea autem sed repellat assumenda deserunt sint eaque. Vel qui cumque. Maiores placeat voluptas ut vero enim in et consequuntur quisquam. Culpa qui alias aut voluptas consequatur iusto.", 4, false, null, null, 18.7623, -154.28630000000001, 8, 10, 37.383598468878709, null, 1, "Odit vitae nihil facilis cupiditate officiis quidem quibusdam vel sit autem veniam corrupti eaque qui aspernatur recusandae.", "Resort" },
                    { 27, "1766 Harold Falls", 3, 1, 1, "Flexible", "Greenholtshire", 53.275011693333489, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sint aspernatur iure a nisi ad reprehenderit quia ab illo. Et sapiente necessitatibus consectetur libero et corporis. Veritatis exercitationem alias velit architecto et soluta repudiandae quod mollitia. Magni beatae qui hic quidem et ipsum nam facilis velit. Et explicabo est odit minus cupiditate exercitationem temporibus autem omnis. Est et sequi quo quae beatae ipsum enim ducimus quod.", 5, false, null, null, 69.389799999999994, -90.280000000000001, 6, 6, 82.796567475415785, null, 3, "Est quia voluptatem dolore sed asperiores velit possimus doloribus qui ut reiciendis aliquam necessitatibus sequi.", "Resort" },
                    { 28, "3765 Kris Fall", 3, 3, 5, "Flexible", "New Antonetta", 29.416482140798067, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Et inventore quia quia tempore ut nihil a iure. Harum nihil eum quasi quisquam doloribus dolorem consequatur voluptate. Enim cupiditate repudiandae fuga et vel sunt velit id.", 3, false, null, null, 39.688000000000002, 38.829599999999999, 2, 2, 85.942844886501305, null, 2, "Expedita beatae esse inventore unde consequuntur consequatur ad in beatae voluptas culpa qui blanditiis et assumenda fugit consectetur qui voluptatem repellendus enim provident eius accusantium et velit.", "Hotel" },
                    { 29, "8415 Carlie Prairie", 2, 5, 5, "Strict", "Larsonmouth", 21.079382892026125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tenetur impedit iure eum tempora sunt occaecati inventore. Iste est error quod ratione quia et consequatur voluptas. Unde voluptas molestiae exercitationem. Dolor eaque adipisci natus sunt consectetur sed reiciendis eum consectetur.", 4, false, null, null, -63.511400000000002, -36.892899999999997, 1, 3, 92.221825946455752, null, 2, "Eos repellat inventore aspernatur ea sequi suscipit possimus dolorem eum et alias quas velit harum voluptatibus tempora aspernatur deleniti voluptas aliquid possimus molestias voluptatem sapiente velit dolore numquam fuga nesciunt.", "Villa" },
                    { 30, "526 Larson Spur", 3, 4, 6, "Flexible", "Kennystad", 32.126738425079509, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cumque inventore nesciunt perspiciatis incidunt voluptatem. Qui quia aut eius sed qui. Quos nihil qui est vitae. Quod molestiae dicta vel quo. Aperiam quisquam error.", 5, false, null, null, -89.390299999999996, 64.050200000000004, 3, 3, 13.39639490291975, null, 3, "At tenetur fugit eos quod optio impedit in eos aut saepe eligendi rerum et deserunt.", "Resort" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingPaymentId", "CancellationPolicyType", "CancellationTicketId", "CheckInDate", "CheckOutDate", "CleaningFee", "CreatedAt", "CreatedBy", "GuestId", "HostPaymentId", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "Note", "NumberOfAdults", "NumberOfChildren", "PricePerNight", "PropertyId", "Status", "SystemFee", "TotalPrice" },
                values: new object[,]
                {
                    { 1, null, "Flexible", null, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 12.228069039653368, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Sint laboriosam id occaecati.", 1, 3, 29.796631215245224, 27, "Completed", 15.244970469791582, 146.65956437042584 },
                    { 2, null, "Strict", null, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), 21.379483389398771, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Quae id ea sunt voluptatum doloribus dolorem alias recusandae nihil.", 2, 5, 92.310049601081943, 13, "Completed", 15.551492562797357, 775.41137276085158 },
                    { 3, null, "Flexible", null, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), 10.822742954992622, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Eligendi hic velit modi non dicta vel.", 3, 4, 33.126918221261398, 5, "Completed", 24.371144751542786, 267.08231525536519 },
                    { 4, null, "Strict", null, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), 22.997045527781705, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Optio et neque voluptatibus a.", 1, 2, 44.320122044771509, 1, "CancelledBeforeCheckIn", 15.188769250806118, 481.38703522630288 },
                    { 5, null, "Flexible", null, new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), 14.825287533149389, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Quod recusandae eos facere veritatis in.", 3, 4, 12.463594257991844, 5, "Completed", 11.936459842546316, 39.225341633687549 },
                    { 6, null, "Flexible", null, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), 14.975417020354923, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Non quos molestias laudantium rerum adipisci at.", 2, 0, 67.123451937992186, 2, "Completed", 20.108034884961008, 303.57725965728469 },
                    { 7, null, "Strict", null, new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 14.498093306793873, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Vitae aut placeat doloribus eos quidem iure est.", 4, 5, 81.058379597994701, 18, "CancelledBeforeCheckIn", 24.386032223654041, 282.05926432443198 },
                    { 8, null, "Flexible", null, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), 14.389668045251213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Ratione ut ut dolores qui.", 5, 0, 23.426542202443429, 30, "Completed", 11.780529618175617, 143.30290867564398 },
                    { 9, null, "Strict", null, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), 10.892660257758129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, false, null, null, "Omnis ut animi error sunt id provident sit sunt.", 1, 2, 61.430027928868519, 14, "CancelledAfterCheckIn", 17.168019681934872, 89.490707868561515 },
                    { 10, null, "Flexible", null, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), 13.282093228910739, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Sunt optio nihil optio.", 2, 5, 51.852196188826731, 3, "Confirmed", 10.844252180802059, 438.94391492032668 },
                    { 11, null, "Strict", null, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), 11.330433994568393, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Rerum deleniti ut facilis esse dolores a.", 5, 5, 24.688369847127973, 18, "CancelledAfterCheckIn", 24.138815221624036, 158.91109845183229 },
                    { 12, null, "Strict", null, new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc), 21.458705320331255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Aspernatur autem officiis dolorum non.", 1, 5, 21.348496030694701, 17, "Confirmed", 22.897084583359991, 215.14375814924887 },
                    { 13, null, "Strict", null, new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), 11.754331824899634, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Officiis est voluptas.", 1, 5, 26.420434094186582, 9, "CheckedIn", 12.218061886079965, 208.91543237028566 },
                    { 14, null, "Strict", null, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Utc), 14.002176651677541, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, false, null, null, "Voluptate quam assumenda molestiae itaque repellat est cum.", 5, 0, 16.016146486702102, 10, "Completed", 12.43793314082264, 138.5531351994149 },
                    { 15, null, "Flexible", null, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), 22.768359974702118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Ea laborum enim perferendis voluptatum esse voluptatum cumque unde.", 2, 1, 32.653267247573815, 21, "Completed", 15.80169862471908, 103.87659309456883 },
                    { 16, null, "Flexible", null, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 24.090863771879643, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Quam et labore.", 4, 1, 59.111076866561909, 9, "Completed", 15.624992560495118, 630.8266249979938 },
                    { 17, null, "Flexible", null, new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc), 23.458394400409848, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, false, null, null, "Nihil repellat numquam quis odio et at molestias aut ut.", 3, 2, 42.663981306563691, 12, "Completed", 18.871118641724316, 84.993494348697851 },
                    { 18, null, "Strict", null, new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Utc), 10.176682351223375, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Eum repellat minima.", 3, 1, 14.268649518655003, 14, "Confirmed", 12.287604228357793, 122.3448332101662 },
                    { 19, null, "Strict", null, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), 22.917935045326953, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Eveniet totam voluptas.", 1, 5, 85.451280132046961, 14, "Completed", 20.07933282235588, 384.80238839587065 },
                    { 20, null, "Flexible", null, new DateTime(2023, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), 12.736893297890285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Ipsam ut et doloremque iste et nobis sint placeat error.", 4, 1, 93.927617287571366, 9, "CancelledAfterCheckIn", 23.672435403164293, 599.97503242648281 },
                    { 21, null, "Strict", null, new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), 22.49992067986593, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Laborum consequatur voluptas facere.", 3, 1, 30.311273119383788, 28, "Rejected", 12.909290946238848, 96.031757864872361 },
                    { 22, null, "Flexible", null, new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), 14.410408757027355, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Laboriosam qui similique et doloremque asperiores possimus in in.", 1, 0, 15.19056271581854, 30, "Rejected", 13.575194288731119, 149.51010477230679 },
                    { 23, null, "Flexible", null, new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Utc), 10.598828753900733, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Harum doloremque repellendus dolores velit reiciendis aut velit expedita voluptatem.", 2, 3, 30.504639743469024, 5, "CancelledBeforeCheckIn", 12.528614312124546, 84.136722552963334 },
                    { 24, null, "Strict", null, new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 26, 0, 0, 0, 0, DateTimeKind.Utc), 10.972869104446389, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Sint expedita non et autem est.", 4, 1, 21.776178812856912, 29, "Completed", 19.630559155285887, 117.70814351115993 },
                    { 25, null, "Strict", null, new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), 12.032201513738556, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Tempora earum sunt et repellendus consequatur qui quo.", 2, 1, 88.818991487379805, 23, "Completed", 18.44497354000459, 829.84809844016138 },
                    { 26, null, "Flexible", null, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 10.933818156252581, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Et quam aut eos omnis autem dignissimos odit et quam.", 5, 0, 32.463577209420762, 2, "Completed", 22.272114521867103, 325.37812756290651 },
                    { 27, null, "Strict", null, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), 22.899633555946352, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Sed minima nemo iste nihil.", 1, 4, 33.36908570510473, 16, "Completed", 17.788321356171714, 107.42612632232752 },
                    { 28, null, "Flexible", null, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), 15.900357029832353, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, false, null, null, "Et eum reiciendis rerum minus autem libero eaque itaque soluta.", 3, 1, 58.116733402659044, 17, "Completed", 11.625335703852919, 143.75915953900338 },
                    { 29, null, "Flexible", null, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), 13.731767710749656, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Quia expedita ab ea natus minus.", 3, 4, 92.312634812769559, 4, "Confirmed", 24.411392672494401, 130.45579519601361 },
                    { 30, null, "Flexible", null, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), 13.214003305814556, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Et deserunt est nulla a vel corrupti voluptatum at ratione.", 2, 5, 25.021394995395067, 4, "CheckedIn", 23.656561606561858, 237.04172487553694 },
                    { 31, null, "Flexible", null, new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), 10.057856604877673, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Architecto facere debitis quod.", 4, 1, 45.011722113225041, 28, "Completed", 14.789583124033078, 204.89432818181092 },
                    { 32, null, "Flexible", null, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 20.937390327436447, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Eum iusto rem repudiandae modi aut quos repellat ut.", 3, 5, 45.689156398675273, 20, "Completed", 17.068435308456856, 129.38413843324383 },
                    { 33, null, "Flexible", null, new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Utc), 24.730871334016491, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, false, null, null, "Debitis molestiae voluptatum dolorem et dicta cumque.", 4, 2, 23.825233721973788, 19, "Completed", 15.412813727915522, 278.3960222816699 },
                    { 34, null, "Strict", null, new DateTime(2023, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), 23.005856230932061, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, false, null, null, "Veritatis sunt iste est omnis non.", 1, 3, 67.883374305219178, 28, "Completed", 15.678652390419686, 174.45125723179012 },
                    { 35, null, "Strict", null, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), 24.900205056731416, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Sunt sunt qui totam porro.", 1, 4, 71.701236934505545, 7, "Pending", 24.247979912608489, 120.84942190384544 },
                    { 36, null, "Flexible", null, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), 21.335915326644358, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Nihil sequi voluptatum omnis voluptas illum.", 4, 1, 76.716491148566064, 25, "Completed", 24.874177224290449, 583.22553059089716 },
                    { 37, null, "Flexible", null, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), 23.690214333548546, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Enim aperiam aut placeat sit non nemo atque tempora omnis.", 3, 4, 40.380465586941057, 20, "Completed", 12.737720999436327, 399.85212561545438 },
                    { 38, null, "Flexible", null, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), 23.149299199328468, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Et amet aut libero in repudiandae debitis reprehenderit.", 2, 3, 98.564014593940797, 26, "CheckedIn", 21.660683410007504, 734.75808476692157 },
                    { 39, null, "Flexible", null, new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), 17.30237289857083, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Aut est eos autem placeat inventore eaque.", 5, 5, 62.523477248070407, 17, "CancelledBeforeCheckIn", 18.50030997250996, 410.94354635950322 },
                    { 40, null, "Flexible", null, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), 21.010708708154553, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Qui consequatur velit est iste ea sint pariatur.", 4, 5, 51.04139801651398, 22, "Completed", 19.701683325401444, 449.04357616566784 },
                    { 41, null, "Strict", null, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), 10.237703739353728, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Dolorem fuga qui ipsum soluta ab ratione.", 1, 3, 33.9733031463647, 23, "Completed", 11.549492372103922, 361.52022757510463 },
                    { 42, null, "Flexible", null, new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), 21.353393506783028, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, false, null, null, "Aliquam odio libero illum cum magnam et totam consequatur.", 5, 3, 14.356156074103101, 7, "CheckedIn", 13.367920718075133, 149.57056281768297 },
                    { 43, null, "Flexible", null, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Utc), 12.221954177437809, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "At ipsum nesciunt sint.", 1, 1, 49.628945104014839, 29, "Completed", 21.003795860856393, 380.62836576639802 },
                    { 44, null, "Flexible", null, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Utc), 11.682922798678572, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Iste placeat quasi dolore eum impedit quo quam illo unde.", 5, 3, 82.427285812460468, 15, "Completed", 10.203247071087144, 846.15902799437038 },
                    { 45, null, "Flexible", null, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Utc), 22.085769525908418, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Asperiores quas enim.", 2, 2, 21.566304517050089, 12, "Completed", 23.376384085425954, 239.55889426478518 },
                    { 46, null, "Flexible", null, new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), 20.801958349229658, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Tempore dolores et non saepe nemo fugit libero ut.", 3, 1, 32.003725807313955, 27, "Completed", 12.750944529494562, 193.57153191529403 },
                    { 47, null, "Flexible", null, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), 20.41756030574901, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Nemo fuga vitae cupiditate maxime sed.", 2, 1, 10.291531637878977, 11, "Completed", 22.259200482894151, 145.59207716743293 },
                    { 48, null, "Strict", null, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), 24.195195231273608, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, false, null, null, "Maiores perspiciatis voluptatem ut quasi sed doloribus sequi sed magni.", 4, 4, 69.675139730297829, 10, "Completed", 24.229581597913107, 118.09991655948456 },
                    { 49, null, "Strict", null, new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 26, 0, 0, 0, 0, DateTimeKind.Utc), 17.676984315178075, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Consequuntur fugit dolorem.", 4, 5, 31.097078624241689, 26, "Completed", 20.749586707287207, 131.71780689519034 },
                    { 50, null, "Flexible", null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), 10.189088986338774, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Fugit itaque expedita quasi dignissimos quae delectus.", 4, 3, 87.08355793144365, 24, "Completed", 17.569723199018206, 463.17660184257522 },
                    { 51, null, "Flexible", null, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), 23.592260768578072, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Tempore sapiente dignissimos excepturi accusantium quos consequatur nisi pariatur rerum.", 1, 2, 23.420455470923375, 22, "Completed", 19.147244309149514, 276.94405978696136 },
                    { 52, null, "Strict", null, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 20.136440456076002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Magni amet sapiente.", 3, 0, 97.053294799829132, 10, "Rejected", 11.220711741162573, 1001.8901001955298 },
                    { 53, null, "Flexible", null, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), 24.310637699465133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Sapiente officiis illo rerum.", 3, 2, 27.852066454166255, 18, "Confirmed", 15.988827442059646, 123.85566450402355 },
                    { 54, null, "Strict", null, new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23.309127138251743, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Eligendi molestias optio nulla totam ipsum nulla.", 1, 2, 92.238336273277227, 22, "CheckedIn", 11.766475360425497, 772.98229268489501 },
                    { 55, null, "Strict", null, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), 22.202144538505081, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, false, null, null, "Quisquam voluptate est et.", 4, 1, 64.093258647318976, 15, "Completed", 19.436080775587371, 105.73148396141143 },
                    { 56, null, "Flexible", null, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), 15.664765842240012, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Iure nobis aut dolore consequatur dolor iure aperiam repellendus.", 1, 5, 60.718797926252968, 12, "Completed", 13.331059286178562, 332.58981475968341 },
                    { 57, null, "Flexible", null, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), 17.88871743330553, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Quia nemo architecto impedit nulla modi minus incidunt modi.", 3, 3, 60.130611476041942, 12, "Completed", 17.589296721896321, 396.26168301145356 },
                    { 58, null, "Flexible", null, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), 14.521839548514912, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Enim maxime incidunt dolorem omnis.", 4, 5, 97.368310221876314, 8, "CancelledAfterCheckIn", 15.772771438053173, 419.7678518740733 },
                    { 59, null, "Strict", null, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Utc), 20.082192222568018, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, false, null, null, "Assumenda enim qui dolores ipsum nihil in dolorem fugit nostrum.", 4, 3, 26.635324567561874, 8, "Pending", 24.325677590650443, 71.043194380780335 },
                    { 60, null, "Strict", null, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), 21.072062563259863, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Porro non est doloribus minus.", 3, 3, 82.265383620407789, 19, "CheckedIn", 10.334519740587297, 113.67196592425495 },
                    { 61, null, "Strict", null, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 16.310859595778844, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Non voluptatem quidem velit unde omnis quae ut repellat.", 3, 5, 89.523364526190832, 14, "Completed", 16.844501396272285, 391.24881909681443 },
                    { 62, null, "Strict", null, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), 24.098964027683067, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Voluptas non quasi corporis ratione hic est.", 3, 2, 94.548945668878616, 28, "Confirmed", 17.528727229185382, 325.27452826350429 },
                    { 63, null, "Strict", null, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), 10.073951285789319, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Aut dolore consequatur perspiciatis corporis quidem corrupti omnis.", 2, 4, 24.182494192008107, 7, "Completed", 22.838718859018201, 202.19012948886427 },
                    { 64, null, "Flexible", null, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), 10.395192586141121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Accusantium accusantium dolores debitis sit sit occaecati ea.", 1, 1, 94.887162329067422, 20, "CancelledBeforeCheckIn", 16.872962374168523, 122.15531728937707 },
                    { 65, null, "Strict", null, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10.113801731222976, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Voluptatem vitae impedit quam animi occaecati facere inventore.", 3, 3, 51.086915081215864, 27, "Completed", 18.514339548631, 181.88888652350155 },
                    { 66, null, "Flexible", null, new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Utc), 16.86516205030652, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Ipsum consequatur alias corporis commodi qui quis dolorem iure.", 2, 0, 14.480253306994463, 2, "Completed", 19.08227670151603, 108.34870528679485 },
                    { 67, null, "Strict", null, new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Utc), 20.259471987736958, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Mollitia non hic ipsa officia amet deleniti ut accusamus voluptatum.", 5, 2, 35.352103279260916, 19, "Completed", 14.408330962014066, 105.37200950827285 },
                    { 68, null, "Strict", null, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), 12.313607753136599, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Repudiandae aliquam praesentium debitis blanditiis.", 3, 0, 73.816107467131474, 21, "Completed", 11.897856236009087, 762.37253866046035 },
                    { 69, null, "Flexible", null, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), 14.771931764848379, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Deserunt quasi esse minus.", 4, 2, 70.396447275985537, 11, "Completed", 18.012778023231775, 666.35273527195011 },
                    { 70, null, "Flexible", null, new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc), 24.059569375283193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Inventore nesciunt quod qui.", 1, 3, 13.191625159522022, 29, "Completed", 22.428637566997164, 59.679832101802376 },
                    { 71, null, "Strict", null, new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Utc), 17.843979746603672, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Dolorem deserunt voluptatem.", 4, 1, 15.48278501887145, 30, "Confirmed", 21.046201844044628, 69.855751628391204 },
                    { 72, null, "Strict", null, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), 14.94371489265659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, false, null, null, "Recusandae culpa consequatur alias ratione adipisci sit ex.", 5, 5, 42.26646146022351, 29, "Confirmed", 13.579734061273877, 408.92160209594209 },
                    { 73, null, "Strict", null, new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), 22.35490496704077, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Enim qui maiores recusandae ipsum.", 1, 5, 74.561533146289563, 11, "Confirmed", 19.89324882955934, 265.93275323546879 },
                    { 74, null, "Flexible", null, new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Utc), 17.949060145537526, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Architecto ad nisi voluptatem eaque esse molestiae voluptate sunt facilis.", 4, 0, 39.179927756951116, 14, "Completed", 21.667432916926348, 78.79642081941499 },
                    { 75, null, "Flexible", null, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), 11.119287048838812, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Facilis harum eligendi odio beatae et aperiam iste.", 2, 1, 59.043851511863146, 24, "Rejected", 17.354345502316161, 618.91214766978646 },
                    { 76, null, "Strict", null, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), 20.892104304980968, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Enim adipisci officia reprehenderit et qui sed.", 3, 3, 39.746436979767253, 15, "Completed", 21.513266039618259, 121.89824430413373 },
                    { 77, null, "Strict", null, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 14.863830001141718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Cum eligendi modi.", 4, 4, 15.568427468074823, 29, "Completed", 17.023979579414807, 187.57208426130472 },
                    { 78, null, "Flexible", null, new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Utc), 16.683869136099595, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Et aut laboriosam.", 2, 4, 73.256232760029349, 11, "Completed", 17.345829556174095, 693.33579353253776 },
                    { 79, null, "Flexible", null, new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), 10.484162970922734, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Velit eum est qui rem quam natus.", 4, 3, 55.310424569563651, 13, "Completed", 18.983490587967825, 140.08850269801786 },
                    { 80, null, "Strict", null, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), 10.965320602863075, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Corrupti consequatur et ut at enim suscipit eveniet.", 5, 0, 20.416491598952625, 25, "CheckedIn", 16.787988741862197, 68.586292542630517 },
                    { 81, null, "Flexible", null, new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), 14.074171137954128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Consequatur eum deleniti excepturi dolorem sed.", 4, 2, 38.695692913360944, 21, "Completed", 24.606172758690917, 348.24588720353256 },
                    { 82, null, "Flexible", null, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 21.377255025041837, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Cumque ducimus totam repellat consequuntur earum.", 5, 5, 37.263095257865629, 21, "Completed", 16.736799795860151, 298.95572162596136 },
                    { 83, null, "Flexible", null, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), 21.129892647743702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "Voluptatem aliquid eligendi minima labore atque.", 3, 3, 90.942614596747859, 20, "CancelledAfterCheckIn", 15.203032186049267, 854.81645620452377 },
                    { 84, null, "Strict", null, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Utc), 21.533976931548857, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Sed modi velit accusantium dicta officiis.", 5, 0, 98.863814075525383, 4, "Completed", 16.413763253376935, 927.72206686465427 },
                    { 85, null, "Strict", null, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), 15.180137567679861, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Amet adipisci quaerat adipisci et et deleniti aut tempore voluptatem.", 3, 1, 94.977198279096825, 8, "Completed", 15.154400069463396, 790.15212386991777 },
                    { 86, null, "Strict", null, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), 10.288865477506496, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Aut ullam voluptas labore sed ducimus aut quisquam id.", 5, 4, 83.143474392835515, 27, "Confirmed", 13.775936385135084, 439.78217382681913 },
                    { 87, null, "Strict", null, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 15.014825873658392, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Temporibus quia sint.", 2, 5, 94.811818840112139, 10, "Completed", 17.341196205537269, 980.47421048031708 },
                    { 88, null, "Strict", null, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Utc), 14.761511222499347, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Blanditiis voluptas iste.", 5, 2, 56.141708484183958, 15, "Completed", 15.568675172505277, 367.18043730010834 },
                    { 89, null, "Strict", null, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Utc), 21.387870283608407, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, false, null, null, "Natus esse dolor.", 1, 2, 78.004456764291646, 24, "Completed", 12.072782595277843, 813.50522052180281 },
                    { 90, null, "Flexible", null, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), 18.146964273290763, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Quos laborum dolor voluptatem deleniti et ut eos quaerat voluptatem.", 3, 0, 48.490019673180711, 27, "Completed", 17.014698469213627, 326.10178078158867 },
                    { 91, null, "Flexible", null, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), 14.94959775614328, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, false, null, null, "In porro modi quia accusantium vel rerum.", 3, 4, 41.232237998776746, 22, "Completed", 22.089827684463884, 325.66509143204445 },
                    { 92, null, "Flexible", null, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), 22.294939901895845, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, false, null, null, "Quasi nihil qui asperiores ratione consequatur.", 3, 5, 26.973582195531137, 5, "Completed", 17.925267736726088, 175.08811861627763 },
                    { 93, null, "Strict", null, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), 24.721072273894901, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, false, null, null, "Molestiae eius et voluptatem deserunt id quo.", 4, 1, 20.837201735857761, 1, "Completed", 11.949391762008219, 161.69367445104967 },
                    { 94, null, "Flexible", null, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), 20.366284393438672, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, false, null, null, "Consectetur culpa tempora corrupti sed ut harum qui laboriosam.", 1, 2, 33.186162083171361, 29, "CancelledAfterCheckIn", 16.138160503286649, 169.24909322941076 },
                    { 95, null, "Flexible", null, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc), 13.370287685679125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, false, null, null, "Recusandae incidunt provident.", 5, 4, 71.380755535743219, 4, "Completed", 16.456365642473841, 315.34967547112581 },
                    { 96, null, "Flexible", null, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), 10.671232138426941, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, false, null, null, "Sapiente eligendi enim.", 4, 3, 91.450810085625776, 2, "Rejected", 14.256697786372369, 665.0836005241797 },
                    { 97, null, "Flexible", null, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc), 14.096065509182695, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, false, null, null, "Sunt sed magni corrupti deserunt quia repellat et eum ipsum.", 3, 3, 29.933202446150652, 15, "CancelledBeforeCheckIn", 19.191212441238108, 63.220480396571453 },
                    { 98, null, "Strict", null, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), 12.21599862025176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, false, null, null, "Ea veniam in quasi voluptatem non minus.", 5, 2, 69.837264987244708, 10, "Completed", 20.45919310534758, 731.04784159804638 },
                    { 99, null, "Flexible", null, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), 13.970213026994006, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, false, null, null, "Exercitationem doloremque id.", 1, 2, 70.274720483493468, 28, "Completed", 17.140575035122893, 593.3085519300646 },
                    { 100, null, "Flexible", null, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), 13.002980282767741, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, false, null, null, "Cumque ex ut delectus voluptate sequi sit.", 5, 2, 45.494733401447327, 21, "CheckedIn", 11.277598822173013, 297.2489795136247 }
                });

            migrationBuilder.InsertData(
                table: "PropertyAmenities",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsAirConditioning", "IsBar", "IsBeachFront", "IsBreakfast", "IsCamperFriendly", "IsDeleted", "IsElevator", "IsGym", "IsHotWater", "IsKitchen", "IsLakeView", "IsLandmarkView", "IsLaptopFriendlyWorkspace", "IsMountainView", "IsRoomService", "IsSeaView", "IsSecurityCamera", "IsSpa", "IsSwimmingPool", "IsTv", "IsWheelchairAccessible", "IsWifi", "LastModifiedAt", "LastModifiedBy", "PropertyId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, true, true, false, false, true, false, false, false, true, false, false, true, true, true, true, false, false, false, true, true, null, null, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, true, false, false, false, false, true, false, false, true, true, true, false, false, false, true, false, true, false, true, false, null, null, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, true, true, true, false, true, false, false, true, false, false, false, false, false, false, true, true, true, false, true, true, null, null, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, true, false, true, false, true, false, false, false, false, false, false, false, true, true, true, true, false, false, true, false, null, null, 4 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, true, true, true, false, true, false, false, true, false, true, true, true, true, true, false, false, false, false, false, false, null, null, 5 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, false, true, false, true, true, true, false, false, true, false, false, true, true, true, true, false, false, true, false, null, null, 6 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, true, true, true, false, false, false, true, false, false, true, true, false, true, false, false, true, true, true, true, false, null, null, 7 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, true, false, false, false, false, false, false, false, true, false, false, false, true, false, true, true, true, false, false, null, null, 8 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, false, true, true, false, true, true, false, true, false, false, true, false, false, true, true, true, true, false, true, true, null, null, 9 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, false, false, true, false, true, false, true, false, true, false, false, true, false, false, false, false, true, false, true, false, null, null, 10 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, false, true, true, false, false, true, false, false, true, true, true, true, true, false, false, true, true, true, true, false, null, null, 11 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, false, false, false, false, false, true, true, false, false, false, false, true, false, false, true, true, true, false, false, false, null, null, 12 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, true, true, true, false, true, true, false, true, false, false, false, false, true, false, false, false, false, true, false, true, null, null, 13 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, true, false, true, false, true, true, true, true, false, false, true, false, true, true, false, false, false, false, false, true, null, null, 14 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, true, true, false, false, true, true, true, false, true, true, true, true, false, true, true, true, false, true, false, true, null, null, 15 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, true, false, true, false, true, false, true, false, false, true, false, true, false, false, false, false, false, true, true, false, null, null, 16 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, false, true, false, true, true, false, false, true, true, true, false, false, true, false, false, true, false, true, true, null, null, 17 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, true, true, true, false, true, true, false, true, true, false, true, true, true, false, true, true, false, true, false, true, null, null, 18 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, true, true, false, true, false, true, true, false, false, false, true, true, true, false, false, true, false, true, true, null, null, 19 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, false, true, false, false, true, true, true, false, false, true, true, true, false, true, false, false, false, false, true, true, null, null, 20 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, true, true, false, false, false, false, true, true, false, false, false, true, true, true, false, false, true, true, false, true, null, null, 21 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, true, false, true, false, false, true, false, false, false, true, true, true, true, true, false, true, true, false, false, false, null, null, 22 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, false, true, false, false, true, true, true, false, true, true, false, false, false, false, true, true, true, false, true, false, null, null, 23 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, true, false, false, false, false, true, false, true, true, false, true, true, true, true, true, true, false, false, true, false, null, null, 24 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, false, false, false, false, true, true, true, false, true, false, false, true, true, false, false, false, false, true, true, true, null, null, 25 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, true, false, false, false, true, true, true, true, true, false, true, false, true, false, false, true, false, true, true, true, null, null, 26 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, true, true, true, true, false, false, false, true, true, true, true, true, true, false, false, false, false, true, true, false, true, null, null, 27 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, true, true, true, false, true, true, true, true, true, true, true, false, true, false, true, false, false, false, true, true, null, null, 28 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, false, false, true, false, true, true, false, false, false, false, false, true, false, true, false, false, false, false, false, false, null, null, 29 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, true, true, true, false, true, true, true, false, true, true, false, true, true, true, false, false, true, false, false, false, null, null, 30 }
                });

            migrationBuilder.InsertData(
                table: "PropertyImages",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LastModifiedAt", "LastModifiedBy", "PropertyId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/3efc49b7-d1e6-4267-87ef-3e42b96e81bd.jpg?im_w=720" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/b17a98ce-517f-4ca8-9261-0f47b96be6b8.jpg?im_w=720" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/0b3e565d-3618-49a9-b11e-82406f94bdcc.jpg?im_w=720" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/64927b50-c1fd-4be7-9d4e-47a93ed2afc2.jpg?im_w=720" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/0d0f29d6-a55b-42f5-bc95-477afb58741e.jpg?im_w=720" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/3efc49b7-d1e6-4267-87ef-3e42b96e81bd.jpg?im_w=720" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/b17a98ce-517f-4ca8-9261-0f47b96be6b8.jpg?im_w=720" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/0b3e565d-3618-49a9-b11e-82406f94bdcc.jpg?im_w=720" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/64927b50-c1fd-4be7-9d4e-47a93ed2afc2.jpg?im_w=720" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/0d0f29d6-a55b-42f5-bc95-477afb58741e.jpg?im_w=720" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/e9ac58a0-22c4-4094-9fdb-56fe0b1128df.jpg?im_w=720" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/bcdc3115-1094-4c75-a7dd-365755b6555f.jpg?im_w=720" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1, "https://a0.muscache.com/im/pictures/a6a57371-87b0-4e35-a697-788a70f91ebd.jpg?im_w=720" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/129db0c1-ab60-4d00-9ccb-bfe944ad658d.jpg?im_w=720" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/efbc479d-0a17-4436-84ba-204a151be9c0.jpg?im_w=720" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/62215b32-d6f0-45c7-8b3a-423484cd5520.jpg?im_w=720" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/d03cfe72-a28c-400b-905c-cd75a06b6035.jpg?im_w=720" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/9f57ef98-7a9a-453a-8eb7-88e0167911b6.jpg?im_w=720" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/129db0c1-ab60-4d00-9ccb-bfe944ad658d.jpg?im_w=720" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/efbc479d-0a17-4436-84ba-204a151be9c0.jpg?im_w=720" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/62215b32-d6f0-45c7-8b3a-423484cd5520.jpg?im_w=720" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/d03cfe72-a28c-400b-905c-cd75a06b6035.jpg?im_w=720" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/9f57ef98-7a9a-453a-8eb7-88e0167911b6.jpg?im_w=720" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/15813474-21b1-478e-a43c-8c80bed317e8.jpg?im_w=720" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2, "https://a0.muscache.com/im/pictures/3afab266-f5bc-4eff-8455-c32e065ce53b.jpg?im_w=720" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/e18d60e5-4833-4ffa-a323-ea1f6d5029d7.jpg?im_w=720" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/021f35ec-b4b7-4c86-8078-618349586d24.jpg?im_w=720" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/b8436281-d84a-4239-a8db-91d013c00bd0.jpg?im_w=720" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/9408a3bf-3266-49d2-b427-5b81d93ed8f9.jpg?im_w=720" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/800ae633-70c8-413e-ad79-5c51f7a54886.jpg?im_w=720" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/b8436281-d84a-4239-a8db-91d013c00bd0.jpg?im_w=720" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/e18d60e5-4833-4ffa-a323-ea1f6d5029d7.jpg?im_w=720" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/021f35ec-b4b7-4c86-8078-618349586d24.jpg?im_w=720" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/800ae633-70c8-413e-ad79-5c51f7a54886.jpg?im_w=720" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/9408a3bf-3266-49d2-b427-5b81d93ed8f9.jpg?im_w=720" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/1bdd0c11-4a2d-4cad-b490-eb3a66cbb690.jpg?im_w=720" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/fc616106-a8ee-429e-8ca4-6946e4df5b68.jpg?im_w=720" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/afcabb76-27b9-46c1-a4ec-8736262d94ef.jpg?im_w=720" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/c5aaf62d-e789-4828-ba01-3adbf19c21d9.jpg?im_w=720" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/c210b551-508c-47cc-bdfc-110c47988a3e.jpg?im_w=720" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3, "https://a0.muscache.com/im/pictures/24eb62fc-cb7a-4114-af4d-fb6eb8abdd1f.jpg?im_w=720" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/miso/Hosting-15248670/original/b924a946-a996-4136-a9e0-3c6e534b9a1f.png?im_w=720" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/8dd8909d-305a-4f66-b966-d1078e62273f.jpg?im_w=720" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/4390134d-2912-4393-a37d-ffcb963f372d.jpg?im_w=720" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/c618624c-7890-45ba-ab83-66f58c23874f.jpg?im_w=720" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/ec5b00a7-b5ac-473f-9c2b-00a70f2dd8dc.jpg?im_w=720" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/miso/Hosting-15248670/original/b924a946-a996-4136-a9e0-3c6e534b9a1f.png?im_w=720" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/8dd8909d-305a-4f66-b966-d1078e62273f.jpg?im_w=720" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/4390134d-2912-4393-a37d-ffcb963f372d.jpg?im_w=720" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/c618624c-7890-45ba-ab83-66f58c23874f.jpg?im_w=720" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/ec5b00a7-b5ac-473f-9c2b-00a70f2dd8dc.jpg?im_w=720" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/615fa9c7-07d6-4473-864a-fe8ff47953b3.jpg?im_w=720" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/a701debb-5742-4eb4-a466-1bcd8d77d2f0.jpg?im_w=720" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/8673dcbb-a1ed-4b98-afea-921fda6c8801.jpg?im_w=720" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4, "https://a0.muscache.com/im/pictures/dc7d628d-1447-418b-a858-462dc6bcbba8.jpg?im_w=720" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/a9897c94-db95-45d3-ba80-a6d369a6ce35.png?im_w=720" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/7fc91c07-9b1b-4075-a591-01f6ba6303cd.jpeg?im_w=720" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/d2ba0a32-6106-4553-b84d-cbb128688b50.png?im_w=720" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/640da3ed-7afd-40fb-92ca-d9762d973116.png?im_w=720" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/d7c183d9-99e8-4f41-9818-fc1d8f2fa042.jpeg?im_w=720" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/a9897c94-db95-45d3-ba80-a6d369a6ce35.png?im_w=720" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/7fc91c07-9b1b-4075-a591-01f6ba6303cd.jpeg?im_w=720" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/d2ba0a32-6106-4553-b84d-cbb128688b50.png?im_w=720" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/640da3ed-7afd-40fb-92ca-d9762d973116.png?im_w=720" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/d7c183d9-99e8-4f41-9818-fc1d8f2fa042.jpeg?im_w=720" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/d0dc594f-eb60-49b1-b27b-2b988152b677.jpeg?im_w=720" },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/2e5a49b4-dcb8-4034-b6db-69e34d494127.png?im_w=720" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5, "https://a0.muscache.com/im/pictures/miso/Hosting-980094225700863202/original/be79b71c-3f15-4ed4-9b33-7f27bfa32b2b.png?im_w=720" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/13f998ea-fb17-4cff-b1c3-07f340f4992c.jpeg?im_w=720" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/331597d7-ec3a-4ead-919c-7f1ac9c02594.jpeg?im_w=720" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/6b91ad89-d49f-40d1-9479-17ac49175eb5.jpeg?im_w=720" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/e4619d7d-72d4-4253-a53b-023aef7af4ef.jpeg?im_w=720" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/cc694739-b1d2-421f-95bb-a5d51319743c.jpeg?im_w=720" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/13f998ea-fb17-4cff-b1c3-07f340f4992c.jpeg?im_w=720" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/331597d7-ec3a-4ead-919c-7f1ac9c02594.jpeg?im_w=720" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/6b91ad89-d49f-40d1-9479-17ac49175eb5.jpeg?im_w=720" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/e4619d7d-72d4-4253-a53b-023aef7af4ef.jpeg?im_w=720" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/cc694739-b1d2-421f-95bb-a5d51319743c.jpeg?im_w=720" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/f870fe9f-ec25-43d8-b294-5b9d50035cb5.jpeg?im_w=720" },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/c120eb7a-8f5f-4ff3-b990-9c15d1c70809.jpeg?im_w=720" },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6, "https://a0.muscache.com/im/pictures/miso/Hosting-579934290861103991/original/fcd529b1-c552-46ae-9084-03c127ee4541.jpeg?im_w=720" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/848639d4-f7dc-4c66-8d00-0ee2784be998.jpeg?im_w=720" },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/90e8c47e-a4d7-429a-99b6-a810894834a8.jpeg?im_w=720" },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/db283d1b-b6a0-4d74-a27e-6be967baf882.jpeg?im_w=720" },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/7cdf1882-bb22-49bc-9c0e-1ab7562b14c7.jpeg?im_w=720" },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/0f46a50a-7ced-4f07-b2c7-68c8c70b093b.jpeg?im_w=720" },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/848639d4-f7dc-4c66-8d00-0ee2784be998.jpeg?im_w=720" },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/90e8c47e-a4d7-429a-99b6-a810894834a8.jpeg?im_w=720" },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/db283d1b-b6a0-4d74-a27e-6be967baf882.jpeg?im_w=720" },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/7cdf1882-bb22-49bc-9c0e-1ab7562b14c7.jpeg?im_w=720" },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/0f46a50a-7ced-4f07-b2c7-68c8c70b093b.jpeg?im_w=720" },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/e9fbfb53-57ec-4079-91bf-66328d87c559.jpeg?im_w=720" },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7, "https://a0.muscache.com/im/pictures/miso/Hosting-877063553937562133/original/654ea2c0-2527-41ba-b1d3-e6ec14dcb387.jpeg?im_w=720" },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-986513611938249048/original/d5e02e66-a9c1-4d7b-9989-54810db2f4bd.jpeg?im_w=720" },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-48946501/original/c6090035-757a-479e-9529-726076d872ec.jpeg?im_w=720" },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-48946501/original/1b07b2c4-f5db-4b85-a530-3ee1396ad363.jpeg?im_w=720" },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-48946501/original/b3b43477-c0dc-42bd-9137-fe6dfa700280.jpeg?im_w=720" },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/a583d59f-437c-4fbb-bcce-27df0cc9d53e.jpg?im_w=720" },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-986513611938249048/original/d5e02e66-a9c1-4d7b-9989-54810db2f4bd.jpeg?im_w=720" },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-48946501/original/c6090035-757a-479e-9529-726076d872ec.jpeg?im_w=720" },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-48946501/original/1b07b2c4-f5db-4b85-a530-3ee1396ad363.jpeg?im_w=720" },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-48946501/original/b3b43477-c0dc-42bd-9137-fe6dfa700280.jpeg?im_w=720" },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/a583d59f-437c-4fbb-bcce-27df0cc9d53e.jpg?im_w=720" },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/bd611b10-bee2-4863-a8e5-2df40cd281da.jpg?im_w=720" },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, "https://a0.muscache.com/im/pictures/miso/Hosting-819422571463623417/original/fd04611f-52e9-4f15-b241-e4ca6c6e06d5.jpeg?im_w=720" },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/f89f83ab-9300-4465-91b8-3146733fc268.jpeg?im_w=720" },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/4a2c5d2c-6e78-4ad5-929b-65af98e8ebf8.jpg?im_w=720" },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/e113a639-f905-4d57-8b2e-84e2cda4da35.jpg?im_w=720" },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/e45bf790-2468-4aa8-b816-369c2d081b85.jpeg?im_w=720" },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/9839ee07-c18f-4833-b61c-f4c7759a8d99.jpg?im_w=720" },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/4a2c5d2c-6e78-4ad5-929b-65af98e8ebf8.jpg?im_w=720" },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/9839ee07-c18f-4833-b61c-f4c7759a8d99.jpg?im_w=720" },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/6469be05-ed63-4349-a1d0-dfb6ef319a21.jpeg?im_w=720" },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/c5addd66-11d3-4e3c-bd71-5566e52518f5.jpeg?im_w=720" },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/fb7bf6c5-8120-41f5-9c93-fb17ed7fb551.jpeg?im_w=720" },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/abd9082e-9a5e-4867-862d-cd86aa11aae3.jpeg?im_w=720" },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/d04ae66f-a185-4ade-b289-e3d8e96f6c4f.jpeg?im_w=720" },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9, "https://a0.muscache.com/im/pictures/miso/Hosting-29378287/original/5a5db07c-92df-494d-b183-0c61db5f4c64.jpeg?im_w=720" },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/miso/Hosting-39313368/original/848ba752-eab1-457b-9d01-d7bf8982a5c9.jpeg?im_w=720" },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/miso/Hosting-39313368/original/a12f2bef-312d-485d-bd77-7ea3da202b38.jpeg?im_w=720" },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/708afe22-a285-451f-829c-0ca99ac168ff.jpg?im_w=720" },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/df31a203-9386-44ef-bb58-6bab3be48154.jpg?im_w=720" },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/miso/Hosting-39313368/original/6e3a0da1-670e-44b3-8da5-ab535c59f815.jpeg?im_w=720" },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/miso/Hosting-39313368/original/a12f2bef-312d-485d-bd77-7ea3da202b38.jpeg?im_w=720" },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/miso/Hosting-39313368/original/848ba752-eab1-457b-9d01-d7bf8982a5c9.jpeg?im_w=720" },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/708afe22-a285-451f-829c-0ca99ac168ff.jpg?im_w=720" },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/miso/Hosting-39313368/original/6e3a0da1-670e-44b3-8da5-ab535c59f815.jpeg?im_w=720" },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/df31a203-9386-44ef-bb58-6bab3be48154.jpg?im_w=720" },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/a16f3dff-37c3-440b-b23a-89dc23bd5558.jpg?im_w=720" },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/miso/Hosting-39313368/original/f18f35d9-76f2-4649-b825-7bf55fbae6ac.jpeg?im_w=720" },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/0faaf955-36a9-4c40-a577-911ec6607ffb.jpg?im_w=720" },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/134cb203-5416-401d-8481-e4a70921478e.jpg?im_w=720" },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/985e4532-c3f2-4ced-abfa-7f39546540b6.jpg?im_w=720" },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10, "https://a0.muscache.com/im/pictures/ce5afa6e-66c5-407f-a748-7db2112948e2.jpg?im_w=720" },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/5b66794e-d8d8-4d03-a86c-c77ce0da4218.jpg?im_w=720" },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/d8024528-a6e0-41d2-a48b-3293ca5d1adb.jpg?im_w=720" },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/1fdf2010-519f-48bc-87cf-1f1f891dacd0.jpg?im_w=720" },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/20ac4ddb-f6c9-4ebf-b46a-54c37ada6430.jpg?im_w=720" },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/b5f4821b-135c-411e-bfd2-5640fc306390.jpg?im_w=720" },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/5b66794e-d8d8-4d03-a86c-c77ce0da4218.jpg?im_w=720" },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/d8024528-a6e0-41d2-a48b-3293ca5d1adb.jpg?im_w=720" },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/1fdf2010-519f-48bc-87cf-1f1f891dacd0.jpg?im_w=720" },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/20ac4ddb-f6c9-4ebf-b46a-54c37ada6430.jpg?im_w=720" },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/b5f4821b-135c-411e-bfd2-5640fc306390.jpg?im_w=720" },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/5dfa9073-02d6-4531-9b9a-b278e96e3323.jpg?im_w=720" },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/3add27cc-31c6-442b-865c-8adb7ab7e085.jpg?im_w=720" },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11, "https://a0.muscache.com/im/pictures/ed29894e-3f50-4994-afca-b52b928a5e58.jpg?im_w=720" },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/673283bb-73c1-4710-95db-7cb682876c2a.jpeg?im_w=720" },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/45302775-cb9e-447b-9d9d-9dc65f8142f1.jpeg?im_w=720" },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/4998dcbc-0b8c-4867-ada5-f5b605980f40.jpeg?im_w=720" },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/5ff7f823-6ad8-4d59-bd32-c73b05953614.jpeg?im_w=720" },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/bd3da88f-53d4-44a7-abb1-0fd4dbf1bc31.jpeg?im_w=720" },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/673283bb-73c1-4710-95db-7cb682876c2a.jpeg?im_w=720" },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/45302775-cb9e-447b-9d9d-9dc65f8142f1.jpeg?im_w=720" },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/4998dcbc-0b8c-4867-ada5-f5b605980f40.jpeg?im_w=720" },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/5ff7f823-6ad8-4d59-bd32-c73b05953614.jpeg?im_w=720" },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/bd3da88f-53d4-44a7-abb1-0fd4dbf1bc31.jpeg?im_w=720" },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/14b61d10-e3f4-4541-90a1-6cf58e274286.jpeg?im_w=720" },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, "https://a0.muscache.com/im/pictures/miso/Hosting-585780078497414982/original/ee81017c-2705-4189-a637-3f4c3b9a1d4a.jpeg?im_w=720" },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/68fc6d12-f555-46c1-a1ea-df6359e6f591.jpeg?im_w=720" },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/25a2ccab-c861-45c0-a07b-329fef02e0ae.jpeg?im_w=720" },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/d2b75a91-b91e-4bb9-b576-8e5431d1fcde.jpeg?im_w=720" },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/e0dd1557-54f1-4983-b171-c09d9a7a86f1.jpeg?im_w=720" },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/bff430d4-007d-434f-a266-61a35ca7aaeb.jpeg?im_w=720" },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/68fc6d12-f555-46c1-a1ea-df6359e6f591.jpeg?im_w=720" },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/76c92575-a2dd-45fb-b0c5-ee1b5f550706.jpeg?im_w=720" },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/5087a69b-109a-4e10-b0bb-3411db58dced.jpeg?im_w=720" },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/25a2ccab-c861-45c0-a07b-329fef02e0ae.jpeg?im_w=720" },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/e0dd1557-54f1-4983-b171-c09d9a7a86f1.jpeg?im_w=720" },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13, "https://a0.muscache.com/im/pictures/miso/Hosting-875631320073456711/original/df2c0205-e21f-4628-acb3-9731b14acc82.jpeg?im_w=720" },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/2347ad5a-e89d-4bd1-bed7-b748defd377e.jpg?im_w=720" },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/83d4fd2d-4130-42cb-8aad-f4c0ce785530.jpg?im_w=720" },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/a5fd8cd5-e160-424d-985c-2480e55caf8f.jpg?im_w=720" },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/8cb880dc-7f1a-43e8-bef9-cf594e813a63.jpg?im_w=720" },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/b931931b-c123-4082-8b99-720f6b1120d6.jpg?im_w=720" },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/2347ad5a-e89d-4bd1-bed7-b748defd377e.jpg?im_w=720" },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/83d4fd2d-4130-42cb-8aad-f4c0ce785530.jpg?im_w=720" },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/a5fd8cd5-e160-424d-985c-2480e55caf8f.jpg?im_w=720" },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/b931931b-c123-4082-8b99-720f6b1120d6.jpg?im_w=720" },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/8cb880dc-7f1a-43e8-bef9-cf594e813a63.jpg?im_w=720" },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/91f7e528-44f1-4d93-bcaa-31742a6679ce.jpg?im_w=720" },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14, "https://a0.muscache.com/im/pictures/7c8e4adf-2964-47c3-b78f-a491daaf93cd.jpg?im_w=720" },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/1cf42d89-7011-4362-bb59-2daf06d4d1fd.jpg?im_w=720" },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/0897c541-e01a-4920-95b7-5e866d2bf1fb.jpg?im_w=720" },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/39424b16-2777-4de5-bcba-e8ad36d3414e.jpg?im_w=720" },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/609624db-db9b-4eda-a34a-3400330b694c.jpg?im_w=720" },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/f06513ce-dab0-405e-8809-89c7b39d16cd.jpg?im_w=720" },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/user/a4eee5da-f6ab-4504-8c7d-08283b97f5c1.jpg?im_w=720" },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/1cf42d89-7011-4362-bb59-2daf06d4d1fd.jpg?im_w=720" },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/0897c541-e01a-4920-95b7-5e866d2bf1fb.jpg?im_w=720" },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/39424b16-2777-4de5-bcba-e8ad36d3414e.jpg?im_w=720" },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/609624db-db9b-4eda-a34a-3400330b694c.jpg?im_w=720" },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/f06513ce-dab0-405e-8809-89c7b39d16cd.jpg?im_w=720" },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/4c9f6911-a388-46e6-8261-d6c4a28d854d.jpg?im_w=720" },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15, "https://a0.muscache.com/im/pictures/463b23bd-2dd8-4fc2-b0b2-7354ab83e9f8.jpg?im_w=720" },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/2d9a4bc7-44e6-42b0-b981-78b923967572.jpeg?im_w=720" },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/41f8673b-d33d-491f-a963-f7ce9a512d28.jpeg?im_w=720" },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/a46d6db4-1113-4072-9b2a-154a7bbeb131.jpeg?im_w=720" },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/c6c38407-d220-474a-b5c9-e32694c29ef6.jpeg?im_w=720" },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/410af6d7-5c36-4e1e-a4ec-b64ef8807827.jpeg?im_w=720" },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/2d9a4bc7-44e6-42b0-b981-78b923967572.jpeg?im_w=720" },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/41f8673b-d33d-491f-a963-f7ce9a512d28.jpeg?im_w=720" },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/a46d6db4-1113-4072-9b2a-154a7bbeb131.jpeg?im_w=720" },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/c6c38407-d220-474a-b5c9-e32694c29ef6.jpeg?im_w=720" },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/410af6d7-5c36-4e1e-a4ec-b64ef8807827.jpeg?im_w=720" },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/68e4e461-0b8b-431e-87d1-82a37d583475.jpeg?im_w=720" },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16, "https://a0.muscache.com/im/pictures/miso/Hosting-588956510910199181/original/63de9dfb-3e53-471d-9865-f84502ac71ca.jpeg?im_w=720" },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/9b3c5226-3847-4768-8c28-f0e76496cd95.png?im_w=720" },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/71a2f30a-dba9-42b1-bea1-0f9b67ccc2fc.jpeg?im_w=720" },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/6ed10fde-172c-4fb2-a7c9-da971b1177fc.jpeg?im_w=720" },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/faae0883-e2aa-4660-9493-5a857f9bc166.jpeg?im_w=720" },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/3af996b6-2729-439b-bbd4-e5281cbf1145.jpeg?im_w=720" },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/71a2f30a-dba9-42b1-bea1-0f9b67ccc2fc.jpeg?im_w=720" },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/7ae40b11-550f-44db-a3ee-8f79d06bcfcc.jpeg?im_w=720" },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/f5a111b4-fc57-4978-a81a-38a0528628a9.jpeg?im_w=720" },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/22cf24e2-62dd-42a5-8038-3e382fec2eb7.jpeg?im_w=720" },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/e2f17684-20c3-4ead-b1c5-039a7d451034.jpeg?im_w=720" },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/5f576e0e-7eab-487f-b550-a111b10f2549.jpeg?im_w=720" },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/77691df9-5b9c-4e33-b729-6e9577213430.jpeg?im_w=720" },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17, "https://a0.muscache.com/im/pictures/miso/Hosting-633520072926487555/original/acf75cd1-dad0-4a0b-8fc6-d15d748c4682.jpeg?im_w=720" },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/101876de-2e8d-4db3-8711-08aec35b2ae5.jpeg?im_w=720" },
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/a17d2e6b-df68-4dab-9379-fc7f2cf1ea3b.jpeg?im_w=720" },
                    { 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/c02c3a98-1495-42c2-a9a3-4c83ba584fd6.jpeg?im_w=720" },
                    { 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/8d30e2f0-4ab7-4892-a11a-e840c5a1e2ce.jpg?im_w=720" },
                    { 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/48b2d9cc-5b42-4d8b-8155-232397996de3.jpeg?im_w=720" },
                    { 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/c02c3a98-1495-42c2-a9a3-4c83ba584fd6.jpeg?im_w=720" },
                    { 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/101876de-2e8d-4db3-8711-08aec35b2ae5.jpeg?im_w=720" },
                    { 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/a17d2e6b-df68-4dab-9379-fc7f2cf1ea3b.jpeg?im_w=720" },
                    { 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/6087f55d-9c9e-4a85-ad11-e1e6b0452f00.jpeg?im_w=720" },
                    { 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/8d30e2f0-4ab7-4892-a11a-e840c5a1e2ce.jpg?im_w=720" },
                    { 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/48b2d9cc-5b42-4d8b-8155-232397996de3.jpeg?im_w=720" },
                    { 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/106cee48-02c6-4db8-bf89-c3b9df431bba.jpeg?im_w=720" },
                    { 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18, "https://a0.muscache.com/im/pictures/miso/Hosting-757590218160457715/original/3bee3df3-72ee-45b0-8819-bc4424b2370b.jpeg?im_w=720" },
                    { 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/c22d1a7b-8107-4651-a7de-98d84ab4b7b3.jpeg?im_w=720" },
                    { 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/c966df6a-2cac-4b33-bccb-dd4c327cc1ec.jpeg?im_w=720" },
                    { 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/750dee2e-8b8a-4448-a5ce-3678e29eb88d.jpeg?im_w=720" },
                    { 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/899c22c8-623c-459e-b7d3-22c476f85518.jpeg?im_w=720" },
                    { 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/c7e224df-3467-4871-ac7d-758769f13161.jpeg?im_w=720" },
                    { 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/c22d1a7b-8107-4651-a7de-98d84ab4b7b3.jpeg?im_w=720" },
                    { 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/c966df6a-2cac-4b33-bccb-dd4c327cc1ec.jpeg?im_w=720" },
                    { 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/750dee2e-8b8a-4448-a5ce-3678e29eb88d.jpeg?im_w=720" },
                    { 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/899c22c8-623c-459e-b7d3-22c476f85518.jpeg?im_w=720" },
                    { 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/c7e224df-3467-4871-ac7d-758769f13161.jpeg?im_w=720" },
                    { 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/51911ae1-a8c8-408f-a35f-d247f4143372.jpeg?im_w=720" },
                    { 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19, "https://a0.muscache.com/im/pictures/miso/Hosting-852562153895631921/original/a7c5c1f7-bf0c-42fc-9984-6ed0d6ff4011.jpeg?im_w=720" },
                    { 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/4e515808-0c93-4be5-b27d-8f37f11df7f4.jpeg?im_w=720" },
                    { 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/fd44bf15-a79a-417b-93f6-9999ed1b0513.jpeg?im_w=720" },
                    { 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/b7d170ca-39e0-4b97-a689-cc18076a9d83.jpeg?im_w=720" },
                    { 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/cecfd631-8076-47d6-af6d-229b7c4b60f4.jpeg?im_w=720" },
                    { 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/6b65209d-ad6d-44a8-a492-6a6fcdb1b525.jpeg?im_w=720" },
                    { 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/ae00f3e5-f753-4106-8add-992748ff6bfd.jpeg?im_w=720" },
                    { 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/6b7c5090-9002-4770-959f-4643dc5a7fb3.jpeg?im_w=720" },
                    { 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/4e515808-0c93-4be5-b27d-8f37f11df7f4.jpeg?im_w=720" },
                    { 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/cecfd631-8076-47d6-af6d-229b7c4b60f4.jpeg?im_w=720" },
                    { 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20, "https://a0.muscache.com/im/pictures/miso/Hosting-588945048670438836/original/6b65209d-ad6d-44a8-a492-6a6fcdb1b525.jpeg?im_w=720" },
                    { 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/2d874882-abe4-4355-b0fd-c2f47122d87e.jpeg?im_w=720" },
                    { 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/6c5763e1-ad37-44a8-964a-ca8a0e68face.jpeg?im_w=720" },
                    { 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/bc67496f-112c-4f7a-bf7a-d8f312e02c6d.jpeg?im_w=720" },
                    { 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/bdcec87c-0f61-47aa-ac32-8e4c6b3783e3.jpeg?im_w=720" },
                    { 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/2de4951e-f671-466d-8201-ed80d2dd5f3c.jpeg?im_w=720" },
                    { 261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/2d874882-abe4-4355-b0fd-c2f47122d87e.jpeg?im_w=720" },
                    { 262, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/6c5763e1-ad37-44a8-964a-ca8a0e68face.jpeg?im_w=720" },
                    { 263, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/bc67496f-112c-4f7a-bf7a-d8f312e02c6d.jpeg?im_w=720" },
                    { 264, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/f4d40953-511b-4f32-a91f-4b2248976712.jpeg?im_w=720" },
                    { 265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/bdcec87c-0f61-47aa-ac32-8e4c6b3783e3.jpeg?im_w=720" },
                    { 266, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/miso/Hosting-45707929/original/2de4951e-f671-466d-8201-ed80d2dd5f3c.jpeg?im_w=720" },
                    { 267, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21, "https://a0.muscache.com/im/pictures/dcbcee21-204c-41d7-b499-bd109d0e51a3.jpg?im_w=720" },
                    { 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/d785e217-9339-4d02-9fb0-9c6fe102bb8d.jpg?im_w=720" },
                    { 269, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/29c7a689-c40d-4802-8d75-d58a54d6273c.jpg?im_w=720" },
                    { 270, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/de14c55f-24cf-4f3b-88ce-5e6c576ffd2f.jpg?im_w=720" },
                    { 271, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/e513334e-6ae3-443d-83ca-1bb8d154c889.jpg?im_w=720" },
                    { 272, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/e15ddb3d-ce64-4c78-9122-d42f4e4cf217.jpg?im_w=720" },
                    { 273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/18eaa01e-6ac3-47d9-849c-36babea0f2de.jpg?im_w=720" },
                    { 274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/e513334e-6ae3-443d-83ca-1bb8d154c889.jpg?im_w=720" },
                    { 275, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/f38e8bae-2f0e-4ee4-90e6-b3a5f71e7978.jpg?im_w=720" },
                    { 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/08656292-98da-4ca0-b4a2-2448461a6dc9.jpg?im_w=720" },
                    { 277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22, "https://a0.muscache.com/im/pictures/3ec543e1-43d0-4495-8f30-459b01abca25.jpg?im_w=720" },
                    { 278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/37c61ff9-e18a-45d0-9172-6761b3cdda20.jpeg?im_w=720" },
                    { 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/8a1994f7-330c-44af-a415-4a105681d60f.jpeg?im_w=720" },
                    { 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/2e836024-6df2-4be4-b7e4-f61414a01580.jpeg?im_w=720" },
                    { 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/a6a12bf0-3e39-486c-9dba-e07335cb35b8.jpeg?im_w=720" },
                    { 282, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/e177c576-c4a5-47f8-b3f7-b7712710de3f.jpeg?im_w=720" },
                    { 283, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/37c61ff9-e18a-45d0-9172-6761b3cdda20.jpeg?im_w=720" },
                    { 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/8a1994f7-330c-44af-a415-4a105681d60f.jpeg?im_w=720" },
                    { 285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/2e836024-6df2-4be4-b7e4-f61414a01580.jpeg?im_w=720" },
                    { 286, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/a6a12bf0-3e39-486c-9dba-e07335cb35b8.jpeg?im_w=720" },
                    { 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/e177c576-c4a5-47f8-b3f7-b7712710de3f.jpeg?im_w=720" },
                    { 288, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/dd977921-92c1-423f-bcc2-d867eb9b20ec.jpeg?im_w=720" },
                    { 289, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23, "https://a0.muscache.com/im/pictures/miso/Hosting-853858468972908675/original/6507a9de-5a5b-40f3-949e-26af093f658b.jpeg?im_w=720" },
                    { 290, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/miso/Hosting-31603969/original/c953a972-605f-45aa-864c-ab56da7f5484.jpeg?im_w=720" },
                    { 291, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/c7c3bc57-07e9-495e-8d5c-c8e47e2e0604.jpg?im_w=720" },
                    { 292, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/miso/Hosting-31603969/original/727cba97-e5cb-4d80-9d9c-a77412ecd1c8.jpeg?im_w=720" },
                    { 293, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/miso/Hosting-31603969/original/78345c01-ffb9-4b8a-aa9f-27edb50e2d21.jpeg?im_w=720" },
                    { 294, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/miso/Hosting-31603969/original/676bd72c-9b11-431d-8d1f-9bb09af4d06c.jpeg?im_w=720" },
                    { 295, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/miso/Hosting-31603969/original/676bd72c-9b11-431d-8d1f-9bb09af4d06c.jpeg?im_w=720" },
                    { 296, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/miso/Hosting-31603969/original/78345c01-ffb9-4b8a-aa9f-27edb50e2d21.jpeg?im_w=720" },
                    { 297, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/4004a5f3-eddc-4d38-a886-b19f355a5377.jpg?im_w=720" },
                    { 298, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/a4a83f05-01b4-4656-aca7-136a9ba62ce5.jpg?im_w=720" },
                    { 299, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24, "https://a0.muscache.com/im/pictures/74f71801-a803-4227-ac81-898251ac6281.jpg?im_w=720" },
                    { 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/bfcb842a-370a-4e1d-bfe2-474408e4043a.jpg?im_w=720" },
                    { 301, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/8052876a-d592-494a-9af3-2466d7a68234.jpg?im_w=720" },
                    { 302, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/50ea12b5-bb5f-4b39-ad73-66e70a4355ee.jpg?im_w=720" },
                    { 303, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/dd15bca9-82b8-4524-b876-6b54bdbe03e9.jpg?im_w=720" },
                    { 304, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/0cb2d50b-66db-4b10-85bc-4e925295354d.jpg?im_w=720" },
                    { 305, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/user/42ae7f2d-642f-4226-9dbe-ec5a09a718ae.jpg?im_w=720" },
                    { 306, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/bfcb842a-370a-4e1d-bfe2-474408e4043a.jpg?im_w=720" },
                    { 307, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/8052876a-d592-494a-9af3-2466d7a68234.jpg?im_w=720" },
                    { 308, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/50ea12b5-bb5f-4b39-ad73-66e70a4355ee.jpg?im_w=720" },
                    { 309, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/dd15bca9-82b8-4524-b876-6b54bdbe03e9.jpg?im_w=720" },
                    { 310, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/0cb2d50b-66db-4b10-85bc-4e925295354d.jpg?im_w=720" },
                    { 311, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/dc9c65e3-6343-4e5a-9798-508377100f60.jpg?im_w=720" },
                    { 312, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25, "https://a0.muscache.com/im/pictures/bb0efde1-4dd0-48d6-9be8-6dfb6f962d7b.jpg?im_w=720" },
                    { 313, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/5ea33708-a33b-4e7b-b365-7fdb48f712e2.jpg?im_w=720" },
                    { 314, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/7a967522-79dd-4b6c-98d5-0a7b93506ffd.JPEG?im_w=720" },
                    { 315, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/8bb121a2-6b75-4eea-a198-f0bdb3a923cf.jpg?im_w=720" },
                    { 316, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/f39435e9-81bf-4031-b8f9-7ec9ab396a4a.JPEG?im_w=720" },
                    { 317, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/fb7f36c2-2268-472e-a0de-3a00c4ccf2ab.JPEG?im_w=720" },
                    { 318, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/7a967522-79dd-4b6c-98d5-0a7b93506ffd.JPEG?im_w=720" },
                    { 319, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/f39435e9-81bf-4031-b8f9-7ec9ab396a4a.JPEG?im_w=720" },
                    { 320, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/fb7f36c2-2268-472e-a0de-3a00c4ccf2ab.JPEG?im_w=720" },
                    { 321, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/7eeac36a-08ab-4183-ae81-d36b06161358.JPEG?im_w=720" },
                    { 322, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/4f43bda3-716b-41a5-b47e-92f6aba7e8d9.JPEG?im_w=720" },
                    { 323, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/07b56672-0c23-4b7f-a47b-f0834c758fd5.JPEG?im_w=720" },
                    { 324, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26, "https://a0.muscache.com/im/pictures/pro_photo_tool/Hosting-38607875-unapproved/original/5ccb3c55-8cb9-4fae-a487-21fee81d54d2.JPEG?im_w=720" },
                    { 325, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/fb651a59-84c7-4773-87e5-95e96ebb3a33.jpeg?im_w=720" },
                    { 326, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/f23d033a-fb04-4cb0-8dba-197ae5863212.jpeg?im_w=720" },
                    { 327, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/268bb713-f79a-4540-97a0-e11d9f646e1b.jpeg?im_w=720" },
                    { 328, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/fa5f3880-267d-4423-9bdb-b5d725070b12.jpeg?im_w=720" },
                    { 329, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/d4dba789-10f7-4fbc-a074-14dcad4340aa.jpeg?im_w=720" },
                    { 330, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/fb651a59-84c7-4773-87e5-95e96ebb3a33.jpeg?im_w=720" },
                    { 331, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/f23d033a-fb04-4cb0-8dba-197ae5863212.jpeg?im_w=720" },
                    { 332, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/268bb713-f79a-4540-97a0-e11d9f646e1b.jpeg?im_w=720" },
                    { 333, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/830f799c-9fa1-4410-97d4-0f2f48694a23.jpeg?im_w=720" },
                    { 334, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/fa5f3880-267d-4423-9bdb-b5d725070b12.jpeg?im_w=720" },
                    { 335, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/d4dba789-10f7-4fbc-a074-14dcad4340aa.jpeg?im_w=720" },
                    { 336, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/a96c0802-1523-43f7-a7a9-a044eeb96ae2.jpeg?im_w=720" },
                    { 337, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/e8418cb1-8107-4fed-a1ca-6968a81a99af.jpeg?im_w=720" },
                    { 338, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27, "https://a0.muscache.com/im/pictures/miso/Hosting-885458424502991441/original/7185628a-69d3-43c0-b1a3-ea205a272c6a.jpeg?im_w=720" },
                    { 339, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/12e38142-adf0-49c6-90f9-822aca4f20cb.jpg?im_w=720" },
                    { 340, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/ddc362a7-467b-473c-9260-a69df549285f.jpg?im_w=720" },
                    { 341, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/b9ec4aa6-0908-4c09-b36a-bb09fad86bf4.jpg?im_w=720" },
                    { 342, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/miso/Hosting-40271468/original/31b9980e-25d3-4759-987c-b3df693f3a3d.jpeg?im_w=720" },
                    { 343, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/b5be14c3-a75c-4983-950c-08fb3bfc4651.jpg?im_w=720" },
                    { 344, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/12e38142-adf0-49c6-90f9-822aca4f20cb.jpg?im_w=720" },
                    { 345, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/ddc362a7-467b-473c-9260-a69df549285f.jpg?im_w=720" },
                    { 346, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/b9ec4aa6-0908-4c09-b36a-bb09fad86bf4.jpg?im_w=720" },
                    { 347, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/b5be14c3-a75c-4983-950c-08fb3bfc4651.jpg?im_w=720" },
                    { 348, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/miso/Hosting-40271468/original/31b9980e-25d3-4759-987c-b3df693f3a3d.jpeg?im_w=720" },
                    { 349, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/miso/Hosting-40271468/original/85236b46-b003-4195-9792-be4579f1e10b.jpeg?im_w=720" },
                    { 350, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/372e6c5a-b38b-41db-9462-06ae6b0408b1.jpg?im_w=720" },
                    { 351, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/miso/Hosting-40271468/original/e194be65-5aef-49d1-9d26-ef00e8135973.jpeg?im_w=720" },
                    { 352, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28, "https://a0.muscache.com/im/pictures/59f492ae-fa77-46b4-af1f-f76f7b689ccd.jpg?im_w=720" },
                    { 353, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/b8e2ec17-1c02-4e14-9c50-a6a128918adf.jpg?im_w=720" },
                    { 354, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/9713348e-a879-40bd-b078-a879eeada8fc.jpeg?im_w=720" },
                    { 355, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/7a11eb64-9e64-42ed-b627-551137afc8e2.jpg?im_w=720" },
                    { 356, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/ee6a400e-76a8-494a-92c0-25e5a9dd6a25.jpeg?im_w=720" },
                    { 357, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/75f3d328-ff1d-4161-bf26-2c983f1fd042.jpeg?im_w=720" },
                    { 358, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/b8e2ec17-1c02-4e14-9c50-a6a128918adf.jpg?im_w=720" },
                    { 359, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/9713348e-a879-40bd-b078-a879eeada8fc.jpeg?im_w=720" },
                    { 360, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/7a11eb64-9e64-42ed-b627-551137afc8e2.jpg?im_w=720" },
                    { 361, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/ee6a400e-76a8-494a-92c0-25e5a9dd6a25.jpeg?im_w=720" },
                    { 362, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/75f3d328-ff1d-4161-bf26-2c983f1fd042.jpeg?im_w=720" },
                    { 363, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/33500322-d64e-4397-91f1-d96017bc9df8.jpeg?im_w=720" },
                    { 364, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29, "https://a0.muscache.com/im/pictures/miso/Hosting-731529863074329049/original/12daad9e-badd-4a74-ac7d-b24a1183675c.jpeg?im_w=720" },
                    { 365, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/24bfef4e-2272-4600-af59-643281d8d13e.jpeg?im_w=720" },
                    { 366, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/489b048f-5f03-4c21-adfc-f77cc9f16a8a.jpg?im_w=720" },
                    { 367, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/61bd7802-a34d-45f1-b642-bab40312347d.jpeg?im_w=720" },
                    { 368, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/ed592d04-a138-4c9a-8b9a-8cd455a01415.jpeg?im_w=720" },
                    { 369, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/efa3933e-0473-4e51-8d42-85a86f15180e.jpeg?im_w=720" },
                    { 370, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/24bfef4e-2272-4600-af59-643281d8d13e.jpeg?im_w=720" },
                    { 371, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/489b048f-5f03-4c21-adfc-f77cc9f16a8a.jpg?im_w=720" },
                    { 372, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/61bd7802-a34d-45f1-b642-bab40312347d.jpeg?im_w=720" },
                    { 373, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/ed592d04-a138-4c9a-8b9a-8cd455a01415.jpeg?im_w=720" },
                    { 374, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/efa3933e-0473-4e51-8d42-85a86f15180e.jpeg?im_w=720" },
                    { 375, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/miso/Hosting-664180361636653954/original/4aa4bfff-8bce-40bc-a72f-8be0b6a6b979.jpeg?im_w=720" },
                    { 376, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30, "https://a0.muscache.com/im/pictures/c0f3fbfa-449f-4df0-bb44-9f1650ec1682.jpg?im_w=720" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PropertyId",
                table: "Bookings",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_CancellationTicketAttachments_CancellationTicketId",
                table: "CancellationTicketAttachments",
                column: "CancellationTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_CancellationTickets_BookingId",
                table: "CancellationTickets",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChargePayments_CancellationTicketId",
                table: "ChargePayments",
                column: "CancellationTicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChargePayments_HostId",
                table: "ChargePayments",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestReviews_GuestId",
                table: "GuestReviews",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestReviews_HostId",
                table: "GuestReviews",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_UserId",
                table: "Guests",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HostPayments_BookingId",
                table: "HostPayments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HostPayments_PaymentInfoId",
                table: "HostPayments",
                column: "PaymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HostReviews_GuestId",
                table: "HostReviews",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_HostReviews_HostId",
                table: "HostReviews",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_UserId",
                table: "Hosts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_HostId",
                table: "PaymentInfos",
                column: "HostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GuestId",
                table: "Payments",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_HostId",
                table: "Properties",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAmenities_PropertyId",
                table: "PropertyAmenities",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyReviews_GuestId",
                table: "PropertyReviews",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyReviews_PropertyId",
                table: "PropertyReviews",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundPayments_CancellationTicketId",
                table: "RefundPayments",
                column: "CancellationTicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefundPayments_GuestId",
                table: "RefundPayments",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_GuestId",
                table: "Wishlists",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_PropertyId",
                table: "Wishlists",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CancellationTicketAttachments");

            migrationBuilder.DropTable(
                name: "ChargePayments");

            migrationBuilder.DropTable(
                name: "GuestReviews");

            migrationBuilder.DropTable(
                name: "HostPayments");

            migrationBuilder.DropTable(
                name: "HostReviews");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PropertyAmenities");

            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.DropTable(
                name: "PropertyReviews");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RefundPayments");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PaymentInfos");

            migrationBuilder.DropTable(
                name: "CancellationTickets");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
