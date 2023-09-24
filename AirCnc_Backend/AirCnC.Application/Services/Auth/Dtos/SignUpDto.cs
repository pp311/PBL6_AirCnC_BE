using System.ComponentModel.DataAnnotations;

namespace AirCnC.Application.Services.Auth.Dtos;

public class SignUpDto
{
    [Required] public string Username { get; set; } = null!;
    [Required] 
    public string FullName { get; set; } = null!;

    [Required] 
    public string Email { get; set; } = null!;
    
    [Required] 
    public string Password { get; set; } = null!;
}