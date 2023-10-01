using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using Quartz;

namespace AirCnC.Application.BackgroundServices;

public class TestJob : IJob
{
    private readonly IRepository<Property> _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TestJob(IRepository<Property> propertyRepository,
                   IUnitOfWork unitOfWork)
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
    }

    // Doi description cua property co id = 1 thanh "Test in {DateTime.Now}"
    public async Task Execute(IJobExecutionContext context)
    {
        var property = await _propertyRepository.GetByIdAsync(1);
        property!.Description = $"Test in {DateTime.Now}";
        
        await _unitOfWork.SaveChangesAsync();
    }
}