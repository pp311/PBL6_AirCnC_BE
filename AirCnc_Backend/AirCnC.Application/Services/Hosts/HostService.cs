using AirCnC.Application.Services.Hosts.Dtos;
using AirCnC.Application.Services.Hosts.Specifications;
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
    private readonly IMapper _mapper;

    public HostService(IRepository<Host> hostRepository,
                       IMapper mapper)
    {
        _hostRepository = hostRepository;
        _mapper = mapper;
    }
    
    public async Task<GetHostDto> GetHostAsync(int id)
    {
        var host = await _hostRepository.FindOneAsync(new HostDetailSpecification(id));
        if (host is null)
            throw new EntityNotFoundException(nameof(Host), id.ToString());
        return _mapper.Map<GetHostDto>(host);
    }
}