using System.ComponentModel.DataAnnotations;

namespace AirCnC.Application.Services.Auth.Dtos;

public class ExternalAuthDto
{
    [Required]
    public string? AccessToken { get; set; } 
}