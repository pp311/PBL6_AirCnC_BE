using AirCnC.Domain.Entities.Base;

namespace AirCnC.Domain.Entities;

public class Wishlist : EntityBase
{
    public int PropertyId { get; set; }
    public Property Property { get; set; } = null!;

    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!; 
}