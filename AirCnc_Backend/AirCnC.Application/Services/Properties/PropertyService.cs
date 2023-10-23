using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Application.Services.Properties.Specifications;
using AirCnC.Application.Services.Reviews.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Exceptions;
using AutoMapper;

namespace AirCnC.Application.Services.Properties;

public interface IPropertyService
{
    Task<PagedList<GetPropertyDto>> GetListAsync(PropertyQueryParameters propertyQueryParameters);
    Task<PagedList<GetPropertyDto>> GetListByHostIdAsync(int hostId, PropertyQueryParameters propertyQueryParameters);
    Task<GetPropertyDto> GetByIdAsync(int id);
    Task<GetPropertyDto> CreateAsync(UpsertPropertyDto upsertPropertyDto);
    Task DeleteByIdAsync(int id);
    Task<GetPropertyDto> UpdateAsync(int id, UpsertPropertyDto upsertPropertyDto);
    Task ConfirmCreatePropertyRequest(int propertyId);
    Task RejectCreatePropertyRequest(int propertyId, RejectPropertyRequestDto dto);
}

public class PropertyService : IPropertyService
{
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Host> _hostRepository;
    private readonly IRepository<PropertyReview> _propertyReviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public PropertyService(IRepository<Property> propertyRepository, 
                           IUnitOfWork unitOfWork, IMapper mapper,
                           ICurrentUser currentUser,
                           IRepository<Host> hostRepository,
                           IRepository<PropertyReview> propertyReviewRepository)
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
        _hostRepository = hostRepository;
        _propertyReviewRepository = propertyReviewRepository;
    }

    public async Task<PagedList<GetPropertyDto>> GetListByHostIdAsync(int hostId, PropertyQueryParameters pqp)
    {
        // t luoi nen dung lai cai spec nay
        var propertyFilterSpec = new PropertyFilterSpecification(pqp, hostId);

        var (items, totalCount) = await _propertyRepository.FindWithTotalCountAsync(propertyFilterSpec);

        var result = _mapper.Map<List<GetPropertyDto>>(items);
        
        // Todo: Optimize this
        foreach (var item in result)
        {
            item.NumberOfReviews = await _propertyReviewRepository.CountAsync(r => r.PropertyId == item.Id);
            if (item.NumberOfReviews == 0) continue;
            item.Rating = await _propertyReviewRepository
                .AverageAsync(new PropertyReviewSpecification(item.Id),
                    r => (r.Accuracy + r.Communication + r.Cleanliness + r.Location + r.CheckIn + r.Value) / 6.0);
        }

        return new PagedList<GetPropertyDto>(result, totalCount, pqp.PageIndex, pqp.PageSize);
    }

    public async Task<GetPropertyDto> GetByIdAsync(int id)
    {
        var propertyFilterSpec = new PropertyDetailSpecification(id);
        var property = await _propertyRepository.FindOneAsync(propertyFilterSpec)
                       ?? throw new EntityNotFoundException(nameof(Property), id.ToString());
        
        var result = _mapper.Map<GetPropertyDto>(property);
        result.NumberOfReviews = await _propertyReviewRepository.CountAsync(r => r.PropertyId == id);
        if (result.NumberOfReviews == 0) return result;
        result.Rating = await _propertyReviewRepository
                                .AverageAsync(new PropertyReviewSpecification(id), 
                                    r => (r.Accuracy + r.Communication + r.Cleanliness + r.Location + r.CheckIn + r.Value) / 6.0);
        return result;
    }

    public async Task<PagedList<GetPropertyDto>> GetListAsync(PropertyQueryParameters pqp)
    {
        var propertyFilterSpec = new PropertyFilterSpecification(pqp);

        var (items, totalCount) = await _propertyRepository.FindWithTotalCountAsync(propertyFilterSpec);

        var result = _mapper.Map<List<GetPropertyDto>>(items);
        
        // Todo: Optimize this
        foreach (var item in result)
        {
            item.NumberOfReviews = await _propertyReviewRepository.CountAsync(r => r.PropertyId == item.Id);
            if (item.NumberOfReviews == 0) continue;
            item.Rating = await _propertyReviewRepository
                .AverageAsync(new PropertyReviewSpecification(item.Id),
                    r => (r.Accuracy + r.Communication + r.Cleanliness + r.Location + r.CheckIn + r.Value) / 6.0);
        }

        return new PagedList<GetPropertyDto>(result, totalCount, pqp.PageIndex, pqp.PageSize);
    }

    public async Task<GetPropertyDto> CreateAsync(UpsertPropertyDto upsertPropertyDto)
    {
        // Get host id of current user
        var userId = int.Parse(_currentUser.Id!);
        var host = await _hostRepository.FindOneAsync(new HostByUserIdSpecification(userId));

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

    public async Task DeleteByIdAsync(int id)
    {
        var property = await _propertyRepository.GetByIdAsync(id) 
                       ?? throw new EntityNotFoundException(nameof(Property), id.ToString());
        _propertyRepository.Delete(property);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<GetPropertyDto> UpdateAsync(int id, UpsertPropertyDto upsertPropertyDto)
    {
        var property = await _propertyRepository.GetByIdAsync(id)
                       ?? throw new EntityNotFoundException(nameof(Property), id.ToString());
        
        _mapper.Map(upsertPropertyDto, property);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<GetPropertyDto>(property);
    }

    public async Task ConfirmCreatePropertyRequest(int propertyId)
    {
        var property = await _propertyRepository.GetByIdAsync(propertyId)
            ?? throw new EntityNotFoundException(nameof(Property), propertyId.ToString());

        property.Status = PropertyStatus.Approved;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RejectCreatePropertyRequest(int propertyId, RejectPropertyRequestDto dto)
    {
        var property = await _propertyRepository.GetByIdAsync(propertyId)
            ?? throw new EntityNotFoundException(nameof(Property), propertyId.ToString());

        property.Status = PropertyStatus.Rejected;
        property.RejectionReason = dto.Reason;
        await _unitOfWork.SaveChangesAsync();
    }
}

public class PropertyMapping : Profile
{
    public PropertyMapping()
    {
        CreateMap<Property, GetPropertyDto>()
            .ForMember(dto => dto.HostName, opt => opt.MapFrom(src => src.Host.User.FullName));
        CreateMap<PropertyImage, GetPropertyImageDto>();
        CreateMap<PropertyUtility, GetPropertyUtilityDto>();
        CreateMap<UpsertPropertyDto,Property>();
        CreateMap<UpsertPropertyImageDto, PropertyImage>();
        CreateMap<PropertyUtilityDto, PropertyUtility>();
    }
}
