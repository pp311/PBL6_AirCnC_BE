using System.Text;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Auth;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Infrastructure;
using AirCnC.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
		return services;
	}
    
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AirCnCDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging();
        });
        return services;
    }
    
    public static IServiceCollection AddCurrentUser(this IServiceCollection services)
    {
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
		services.Configure<GoogleSettings>(configuration.GetSection("Authentication:Google"));
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
		});

		return services;
	}
}