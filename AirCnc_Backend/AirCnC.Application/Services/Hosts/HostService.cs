using AirCnC.Application.Services.Hosts.Dtos;
using AirCnC.Application.Services.Hosts.Specifications;
using AirCnC.Application.Services.Reviews.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AutoMapper;

namespace AirCnC.Application.Services.Hosts;

public interface IHostService
{
    Task<GetHostDto> GetHostAsync(int id);
}
public class HostService : IHostService
{
    private readonly IRepository<Host> _hostRepository;
    private readonly IRepository<HostReview> _hostReviewRepository;
    private readonly IMapper _mapper;

    public HostService(IRepository<Host> hostRepository,
                       IMapper mapper,
                       IRepository<HostReview> hostReviewRepository)
    {
        _hostRepository = hostRepository;
        _mapper = mapper;
        _hostReviewRepository = hostReviewRepository;
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
}