using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.PropertyService.Dtos;
using AirCnC.Application.Services.PropertyService.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AutoMapper;

namespace AirCnC.Application.Services.PropertyService;

public interface IPropertyService
{
    Task<PagedList<GetPropertyDto>> GetListAsync(PropertyQueryParameters propertyQueryParameters);
    Task<GetPropertyDto?> GetByIdAsync(int id);
    Task<GetPropertyDto> CreateAsync(UpsertPropertyDto upsertPropertyDto);
    Task<GetPropertyDto?> DeleteByIdAsync(int id);
    Task<GetPropertyDto?> UpdateAsync(int id, UpsertPropertyDto upsertPropertyDto);
}

public class PropertyService : IPropertyService
{
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Host> _hostRepository;
    //private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public PropertyService(IRepository<Property> propertyRepository, IUnitOfWork unitOfWork, IMapper mapper,
                           ICurrentUser currentUser,
                           IRepository<Host> hostRepository)
    {
        _propertyRepository = propertyRepository;
        //_userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
        _hostRepository = hostRepository;
    }

    public async Task<GetPropertyDto?> GetByIdAsync(int id)
    {
        var propertyFilterSpec = new PropertyDetailSpecification(id);
        var property = await _propertyRepository.FindOneAsync(propertyFilterSpec);
        if (property is null)
            return null;
        return _mapper.Map<GetPropertyDto>(property);
    }

    public async Task<PagedList<GetPropertyDto>> GetListAsync(PropertyQueryParameters pqp)
    {
        var propertyFilterSpec = new PropertyFilterSpecification(pqp);


        var (items, totalCount) = await _propertyRepository.FindWithTotalCountAsync(propertyFilterSpec);

        var result = _mapper.Map<List<GetPropertyDto>>(items);

        return new PagedList<GetPropertyDto>(result, totalCount, pqp.PageIndex, pqp.PageSize);
    }

    public async Task<GetPropertyDto> CreateAsync(UpsertPropertyDto upsertPropertyDto)
    {
        // Get host id of current user
        var userId = int.Parse(_currentUser.Id!);
        var host = await _hostRepository.FindOneAsync(new GetHostByUserIdSpecification(userId));

        // Create host profile if not exist
        if (host is null)
        {
            host = new Host { UserId = userId };
            _hostRepository.Add(host);
        }

        // Create property as pending
        var property = _mapper.Map<Property>(upsertPropertyDto);
        property.Status = PropertyStatus.Pending;
        host.Properties.Add(property);

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GetPropertyDto>(property);
    }

    public async Task<GetPropertyDto?> DeleteByIdAsync(int id)
    {
        var property = await _propertyRepository.GetByIdAsync(id);
        if (property is null)
        {
            return null;
        }
        _propertyRepository.Delete(property);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GetPropertyDto>(property);
    }

    public async Task<GetPropertyDto?> UpdateAsync(int id, UpsertPropertyDto upsertPropertyDto)
    {
        var property = await _propertyRepository.GetByIdAsync(id);
        if (property is null)
        {
            return null;
        }
        _mapper.Map(upsertPropertyDto, property);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GetPropertyDto>(property);
    }
}
