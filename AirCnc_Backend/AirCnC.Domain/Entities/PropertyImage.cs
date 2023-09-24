using AirCnC.Domain.Entities.Base;

namespace AirCnC.Domain.Entities;

public class PropertyImage : EntityBase
{
    public int PropertyId { get; set; }
    public Property Property { get; set; } = null!;

    public string Url { get; set; } = string.Empty;
}