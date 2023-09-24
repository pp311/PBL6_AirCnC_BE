using AirCnC.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.API.Extensions;

public static class MigrateExtension
{
   public static async Task ApplyMigrationAsync(this IApplicationBuilder app, ILogger logger)
       {
           using var scope = app.ApplicationServices.CreateScope();
   
           var context = scope.ServiceProvider.GetRequiredService<AirCnCDbContext>();
           logger.LogInformation("Migrating pending migration...");   

           await context.Database.MigrateAsync();

           logger.LogInformation("Migrated successfully!");
       } 
}