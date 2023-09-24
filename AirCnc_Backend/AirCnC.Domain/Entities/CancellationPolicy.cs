using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Enums;

namespace AirCnC.Domain.Entities;

public class CancellationPolicy : EntityBase
{
    public CancellationPolicyType Type { get; set; }
    public string? Description { get; set; }
    
    public ICollection<Property> Properties { get; set; } = null!; 
}