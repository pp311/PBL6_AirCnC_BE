using System.ComponentModel.DataAnnotations;

namespace AirCnC.Application.Services.PropertyService.Dtos;

public class RejectPropertyRequestDto
{
    [Required] public string? Reason { get; set; }
}