namespace AirCnC.Domain.Enums;

public enum BookingStatus
{
    Pending = 1,
    Confirmed,
    Rejected,
    CancelledBeforeCheckIn, 
    CancelledAfterCheckIn,
}