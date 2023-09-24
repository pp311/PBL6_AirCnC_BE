using AirCnC.Domain.Entities.Base;

namespace AirCnC.Domain.Entities;

public class HostReview : EntityBase
{
    public int HostId { get; set; }
    public Host Host { get; set; } = null!;
    public int GuestId { get; set; }
    public Guest Guest { get; set; } = null!;
    public string Content { get; set; } = string.Empty;
}