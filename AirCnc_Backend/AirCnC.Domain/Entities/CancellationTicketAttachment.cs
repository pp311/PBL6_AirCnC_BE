using AirCnC.Domain.Entities.Base;

namespace AirCnC.Domain.Entities;

public class CancellationTicketAttachment : EntityBase
{
    public string Url { get; set; } = string.Empty; 
    
    public int CancellationTicketId { get; set; }
    public CancellationTicket CancellationTicket { get; set; } = null!;
}