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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                name: "CancellationPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationPolicies", x => x.Id);
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
                    BathroomCount = table.Column<int>(type: "int", nullable: false),
                    MaxAdultCount = table.Column<int>(type: "int", nullable: false),
                    MaxChildCount = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(13,10)", precision: 13, scale: 10, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(13,10)", precision: 13, scale: 10, nullable: false),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    CleaningFee = table.Column<double>(type: "float", nullable: false),
                    CancellationPolicyId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Properties_CancellationPolicies_CancellationPolicyId",
                        column: x => x.CancellationPolicyId,
                        principalTable: "CancellationPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FullName", "Introduction", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, null, null, "c1226c3a-6769-4e60-be64-3d92ed93ecfa", null, "admin@gmail.com", true, "Phuc Phan", null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAELz+UBsGb+gWZYknAD2NlnMBTyZbmCN7MzHqfzkr8GHwVsoL/pdvLiUei1DjRhweIA==", null, false, "b8dea0bd-4546-43c4-853c-fbae9ab4e1e1", null, false, "admin" },
                    { 3, 0, null, null, null, "f301ad66-3c57-4aad-8df4-834bbc118938", null, "Rico_Hahn37@hotmail.com", false, "Brady Waters", null, false, false, null, null, null, null, null, false, "c0ca9b7f-6a6c-4956-9983-4c6224ba5d0e", null, false, "Rico_Hahn37@hotmail.com" },
                    { 4, 0, null, null, null, "a0e53abc-3363-4807-97aa-b4d87629a9ec", null, "Jedidiah_Herman46@gmail.com", false, "Blaise Farrell", null, false, false, null, null, null, null, null, false, "3b6158c5-db33-4eb1-a103-2f34b5cc95f1", null, false, "Jedidiah_Herman46@gmail.com" },
                    { 5, 0, null, null, null, "b5282f15-5635-4bc1-8121-f59887a8144f", null, "Barrett59@gmail.com", false, "Verona Kemmer", null, false, false, null, null, null, null, null, false, "3b9a30b8-e1d7-42cd-a869-a049ea1b3723", null, false, "Barrett59@gmail.com" },
                    { 6, 0, null, null, null, "8c7a6a6f-ff84-4f4f-8c37-ace3fed53a6f", null, "Lia.Braun@yahoo.com", false, "Loren O'Keefe", null, false, false, null, null, null, null, null, false, "28b18f33-ab7e-4f64-93ce-c6bdc229b845", null, false, "Lia.Braun@yahoo.com" },
                    { 7, 0, null, null, null, "ef438abe-0371-4808-8326-4a7e46cf02b5", null, "Anissa_McGlynn29@yahoo.com", false, "Vilma Kreiger", null, false, false, null, null, null, null, null, false, "6dc9fbcf-9400-445e-b683-7099011e4d99", null, false, "Anissa_McGlynn29@yahoo.com" },
                    { 8, 0, null, null, null, "94ed5cc1-9049-4c30-acb8-a3a3805d6bb3", null, "Kaela.Schulist35@hotmail.com", false, "Mason Fay", null, false, false, null, null, null, null, null, false, "7839442a-53c8-4d0a-b87a-a794030dfcd5", null, false, "Kaela.Schulist35@hotmail.com" },
                    { 9, 0, null, null, null, "095382bc-29f4-447d-8f44-750b76cb5f6d", null, "Kody94@hotmail.com", false, "Madisyn Parker", null, false, false, null, null, null, null, null, false, "e18d5907-5461-4ca6-bed5-7a0e5f91ed4c", null, false, "Kody94@hotmail.com" },
                    { 10, 0, null, null, null, "730c05ee-d999-4519-a9f6-3669e2de2a75", null, "Delbert_Hane@gmail.com", false, "General Daugherty", null, false, false, null, null, null, null, null, false, "9cf013f6-6648-4cb2-8496-426e798bbc65", null, false, "Delbert_Hane@gmail.com" },
                    { 11, 0, null, null, null, "35571b9a-dc50-48ed-88e7-fd95740d41cb", null, "Emory_Barrows11@yahoo.com", false, "Maryse Altenwerth", null, false, false, null, null, null, null, null, false, "323074ea-c544-4870-b31b-de2a19b78dd9", null, false, "Emory_Barrows11@yahoo.com" },
                    { 12, 0, null, null, null, "70db9ad9-c775-437b-b5bc-1cf62b7ea8c5", null, "Newton_Fritsch68@hotmail.com", false, "Geoffrey Shields", null, false, false, null, null, null, null, null, false, "570095c0-e6cd-44e2-84ec-04eb3b1cc0f1", null, false, "Newton_Fritsch68@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 }
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
                name: "IX_Properties_CancellationPolicyId",
                table: "Properties",
                column: "CancellationPolicyId");

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
                name: "CancellationPolicies");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
