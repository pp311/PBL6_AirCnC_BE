using System.Text.Json.Serialization;
using AirCnC.API.Chat;
using AirCnC.API.Extensions;
using AirCnC.API.Middlewares;
using AirCnC.Application.Commons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
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
    .AddEmailSender()
    .AddCloudinary(builder.Configuration)
    .AddQuartz()
    .AddLogging(builder.Configuration)
    .AddSignalR();

builder.Services.AddAutoMapper(typeof(IApplicationAssemblyMarker));

var app = builder.Build();

await app.ApplyMigrationAsync(app.Logger);

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCustomExceptionHandler(app.Environment);

// app.UseHttpsRedirection();

app.UseCors("AirCnC");
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chathub");
app.MapControllers();
app.Run();
