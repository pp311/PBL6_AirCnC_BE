using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using Quartz;

namespace AirCnC.Application.BackgroundServices;

public class RemovePendingBookingJob : IJob
{
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemovePendingBookingJob(IRepository<Booking> bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var bookings = await _bookingRepository.FindListAsync(new ExpiredBookingSpecification());
        _bookingRepository.RemoveRange(bookings);
        await _unitOfWork.SaveChangesAsync();
    }
}