namespace AirCnC.Application.Services.Cancellations.Dtos;

public class AcceptCancellationTicketDto
{
    public string? ResolveNote { get; set; }
    public double RefundAmount { get; set; }
    public double ChargeAmount { get; set; }
}