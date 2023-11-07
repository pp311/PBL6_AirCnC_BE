using AirCnC.Application.Commons;
using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Application.Services.CheckIn.Specifications;
using AirCnC.Application.Services.Hosts.Dtos;
using AirCnC.Application.Services.Hosts.Specifications;
using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Application.Services.Reviews.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AutoMapper;

namespace AirCnC.Application.Services.Hosts;

public interface IHostService
{
    Task<GetHostDto> GetHostAsync(int id);
    Task<PagedList<GetHostForAdminDto>> GetHostsAsync(PagingParameters pp);
}
public class HostService : IHostService
{
    private readonly IRepository<Host> _hostRepository;
    private readonly IRepository<HostReview> _hostReviewRepository;
    private readonly IRepository<Property> _PropertyRepository;
    private readonly IRepository<Booking> _BookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HostService(IRepository<Host> hostRepository, IMapper mapper, IUnitOfWork unitOfWork,
    IRepository<HostReview> hostReviewRepository, IRepository<Property> propertyRepository,
                       IRepository<Booking> bookingRepository)
    {
        _hostRepository = hostRepository;
        _mapper = mapper;
        _hostReviewRepository = hostReviewRepository;
        _PropertyRepository = propertyRepository;
        _BookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<GetHostDto> GetHostAsync(int id)
    {
        var host = await _hostRepository.FindOneAsync(new HostDetailSpecification(id));
        if (host is null)
            throw new EntityNotFoundException(nameof(Host), id.ToString());
        
        var result = _mapper.Map<GetHostDto>(host);
        result.NumberOfReviews = await _hostReviewRepository.CountAsync(h => h.HostId == id);
        result.Rating = await _hostReviewRepository.AverageAsync(new HostReviewSpecification(id), h => h.Rating); 
        return result;
    }

    public async Task<PagedList<GetHostForAdminDto>> GetHostsAsync(PagingParameters pp)
    {
        var spec = new HostsPagingSpecification(pp);
        var (hosts,totalCount) = await _hostRepository.FindWithTotalCountAsync(spec);
        if (hosts is null)
            throw new EntityNotFoundException(nameof(Host), pp.PageIndex.ToString());
        var result = _mapper.Map<List<GetHostForAdminDto>>(hosts);
        foreach (var host in result)
        {
            host.NumberOfReviews = await _hostReviewRepository.CountAsync(h => h.HostId == host.Id);
            host.Rating = await _hostReviewRepository.AverageAsync(new HostReviewSpecification(host.Id), h => h.Rating);
            host.NumberOfProperties = await _PropertyRepository.CountAsync(p => p.HostId == host.Id);
            host.NumberOfBookings = await _BookingRepository.CountAsync(b => b.Property.HostId == host.Id);
            host.TotalIncome= await _BookingRepository.SumAsync(new GetBookingWithHostSpecification(host.Id), b => b.TotalPrice);
        }
        return new PagedList<GetHostForAdminDto>(result, totalCount, pp.PageIndex, pp.PageSize);
    }
}