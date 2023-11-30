using System.Reflection;
using System.Text;
using AirCnC.API.Common.Identity;
using AirCnC.Application.BackgroundServices;
using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Helpers;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Services.Auth;
using AirCnC.Application.Services.Bookings;
using AirCnC.Application.Services.Cancellations;
using AirCnC.Application.Services.Chat;
using AirCnC.Application.Services.CheckIn;
using AirCnC.Application.Services.Email;
using AirCnC.Application.Services.Guests;
using AirCnC.Application.Services.HostPayments;
using AirCnC.Application.Services.Hosts;
using AirCnC.Application.Services.ImageUploader;
using AirCnC.Application.Services.Payments;
using AirCnC.Application.Services.Payments.Dtos;
using AirCnC.Application.Services.Properties;
using AirCnC.Application.Services.Reviews;
using AirCnC.Application.Services.Users;
using AirCnC.Application.Services.Wishlists;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Infrastructure.Cloudinary;
using AirCnC.Infrastructure.Data;
using AirCnC.Infrastructure.Email;
using AirCnC.Infrastructure.Repositories;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace AirCnC.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IHostService, HostService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IWishlistService, WishlistService>();
        services.AddScoped<ICheckInService,CheckInService>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<ICancellationService, CancellationService>();
        services.AddScoped<IHostPaymentService,HostPaymentService>();
        services.AddScoped<IChatService, ChatService>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AirCnCDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging();
            // log loi chi tiet hon nhung lam giam hieu nang
            options.EnableDetailedErrors();
            // options.LogTo(new StreamWriter("./Logs/EFCore.log", true).WriteLine);
        });
        return services;
    }

    public static IServiceCollection AddCurrentUser(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddHttpContextAccessor();
        return services;
    }

    public static IServiceCollection AddApplicationCors(this IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy("AirCnC", builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        return services;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<int>>(options =>
                    {
                        options.Password.RequiredLength = 8;
                        options.Password.RequireDigit = true;
                        options.Password.RequireUppercase = true;
                        options.Password.RequireLowercase = true;
                        options.Password.RequireDigit = true;
                        options.Password.RequireNonAlphanumeric = true;

                        options.User.RequireUniqueEmail = true;
                    })
                    .AddEntityFrameworkStores<AirCnCDbContext>()
                    .AddDefaultTokenProviders();
        return services;
    }

    public static IServiceCollection ConfigureConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<EmailSettings>(configuration.GetSection("EmailConfiguration"));
        services.Configure<AirCnCSettings>(configuration.GetSection("AirCnC"));
        services.Configure<PaymentConfig>(configuration.GetSection("PaymentConfig"));
        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>()
                                  ?? throw new NullReferenceException("JwtSettings not found");

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.SecurityKey ??
                                               throw new Exception("SecurityKey is null.)"))),
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
    
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/chathub")))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services, string applicationName, string version = "v1")
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc(version, new OpenApiInfo
            {
                Title = applicationName,
                Version = version
            });

            config.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                BearerFormat = "JWT",
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }
    
    public static IServiceCollection AddEmailSender(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IMailTemplateHelper, MailTemplateHelper>();
        return services;
    }

    public static IServiceCollection AddCloudinary(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<Cloudinary>(_ =>
        {
            var cloudinarySection = configuration.GetSection("Cloudinary");
            var account = new Account
            {
                Cloud = cloudinarySection["CloudName"],
                ApiKey = cloudinarySection["ApiKey"],
                ApiSecret = cloudinarySection["ApiSecret"]
            };

            return new Cloudinary(account);
        });

        services.AddScoped<IImageUploader, CloudinaryImageUploader>();

        return services;
    }

    public static IServiceCollection AddQuartz(this IServiceCollection services)
    {
        services.AddQuartz(options =>
        {
            var jobKey = new JobKey("RemovePendingBookingJob");
            options.AddJob<RemovePendingBookingJob>(jobKey)
                   .AddTrigger(trigger =>
                        trigger.ForJob(jobKey)
                            .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInMinutes(3)
                                        .RepeatForever()));
            
            // Run at 12:00 PM every day
            var jobKey2 = new JobKey("MarkCheckoutDateBookingJob");
            options.AddJob<MarkCheckOutJob>(jobKey2)
                   .AddTrigger(trigger =>
                        trigger.ForJob(jobKey2)
                            .WithCronSchedule("0 0 12 * * ? *"));
        });

        services.AddQuartzHostedService(options =>
        {
            options.AwaitApplicationStarted = true;
            options.WaitForJobsToComplete = true;
        });
            
        return services;
    }

    public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Console(theme: SerilogCustomTheme.CustomTheme, 
                restrictedToMinimumLevel: LogEventLevel.Information,
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}")
            .CreateLogger();
        
        services.AddHttpLogging(options =>
        {
            options.LoggingFields = HttpLoggingFields.RequestMethod |
                                    HttpLoggingFields.RequestPath |
                                    HttpLoggingFields.ResponseStatusCode;
        });

        return services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog(dispose: true);
            loggingBuilder.AddAzureWebAppDiagnostics();
        }); 
    }

    private static class SerilogCustomTheme
    {
        public static SystemConsoleTheme CustomTheme { get; } = new( 
            new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
            {
                [ConsoleThemeStyle.Text] = new() { Foreground = ConsoleColor.White },
                [ConsoleThemeStyle.SecondaryText] = new() { Foreground = ConsoleColor.Gray },
                [ConsoleThemeStyle.TertiaryText] = new() { Foreground = ConsoleColor.DarkGray },
                [ConsoleThemeStyle.Invalid] = new() { Foreground = ConsoleColor.Yellow },
                [ConsoleThemeStyle.Null] = new() { Foreground = ConsoleColor.Blue },
                [ConsoleThemeStyle.Name] = new() { Foreground = ConsoleColor.Gray },
                [ConsoleThemeStyle.String] = new() { Foreground = ConsoleColor.Green },
                [ConsoleThemeStyle.Number] = new() { Foreground = ConsoleColor.Magenta },
                [ConsoleThemeStyle.Boolean] = new() { Foreground = ConsoleColor.Blue },
                [ConsoleThemeStyle.Scalar] = new() { Foreground = ConsoleColor.Green },
                [ConsoleThemeStyle.LevelVerbose] = new() { Foreground = ConsoleColor.Gray },
                [ConsoleThemeStyle.LevelDebug] = new() { Foreground = ConsoleColor.Gray },
                [ConsoleThemeStyle.LevelInformation] = new() { Foreground = ConsoleColor.Green },
                [ConsoleThemeStyle.LevelWarning] = new() { Foreground = ConsoleColor.Yellow },
                [ConsoleThemeStyle.LevelError] = new() { Foreground = ConsoleColor.White, Background = ConsoleColor.Red },
                [ConsoleThemeStyle.LevelFatal] = new() { Foreground = ConsoleColor.White, Background = ConsoleColor.Red },
            });
    }
}
