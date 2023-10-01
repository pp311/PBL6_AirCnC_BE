using AirCnC.API.Extensions;
using AirCnC.API.Middlewares;
using AirCnC.Application.Commons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration)
    .AddRepositories()
    .AddServices()
    .AddCurrentUser()
    .AddApplicationCors()
    .ConfigureIdentity()
    .ConfigureConfigurations(builder.Configuration)
    .AddAuthentication(builder.Configuration)
    .AddSwagger("AirCnC")
    .AddCloudinary(builder.Configuration)
    .AddQuartz();

builder.Services.AddAutoMapper(typeof(IApplicationAssemblyMarker));

var app = builder.Build();

await app.ApplyMigrationAsync(app.Logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler(app.Environment);

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
