using AirCnC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.API.Extensions;

public static class MigrateExtension
{
   public static async Task ApplyMigrationAsync(this IApplicationBuilder app, ILogger logger)
       {
           using var scope = app.ApplicationServices.CreateScope();
   
           var context = scope.ServiceProvider.GetRequiredService<AirCnCDbContext>();
           await context.Database.MigrateAsync();
           // var retryCount = 0;
           // while (retryCount < 5)
           // {
           //     try
           //     {
           //         if (!(await context.Database.GetPendingMigrationsAsync()).Any()) return;
           //         logger.LogInformation("Migrating pending migration...");
           //
           //         await context.Database.MigrateAsync();
           //         logger.LogInformation("Migrated successfully!");
           //     } 
           //     catch (Exception e)
           //     {
           //         logger.LogError(e, "An error occurred while migrating the database");
           //         retryCount++;
           //         await Task.Delay(TimeSpan.FromSeconds(1));
           //     }
           // }
       } 
}