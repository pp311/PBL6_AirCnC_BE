using System.ComponentModel.DataAnnotations;

namespace AirCnC.Application.Services.Properties.Dtos;

public class RejectPropertyRequestDto
{
    [Required] public string? Reason { get; set; }
}