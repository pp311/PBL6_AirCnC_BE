namespace AirCnC.Domain.Enums;

public enum CancellationTicketType
{
    CancelledBefore14Days = 1,
    CancelledBefore1Days,
    CancelledBefore2Days,
    CancelledBefore3Days,
    CancelledBeforeCheckIn,
    CancelledAfterCheckIn,
}