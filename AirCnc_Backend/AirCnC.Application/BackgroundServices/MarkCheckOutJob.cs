using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using Quartz;

namespace AirCnC.Application.BackgroundServices;

public class MarkCheckOutJob : IJob
{
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MarkCheckOutJob(IRepository<Booking> bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var bookings = await _bookingRepository.FindListAsync(new ExpiredBookingSpecification());
        foreach (var booking in bookings)
        {
            booking.Status = BookingStatus.Completed;
        }
        await _unitOfWork.SaveChangesAsync();
    }
}