using AirCnC.Application.Commons;
using AirCnC.Application.Services.Auth;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Infrastructure;
using AirCnC.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
		return services;
	}
}