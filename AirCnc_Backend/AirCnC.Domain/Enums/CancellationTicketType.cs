namespace AirCnC.Domain.Enums;

public enum CancellationTicketType
{
    CancelledBefore14Days = 1,
    CancelledBefore3Days,
    CancelledBeforeCheckIn,
    CancelledAfterCheckIn,
}