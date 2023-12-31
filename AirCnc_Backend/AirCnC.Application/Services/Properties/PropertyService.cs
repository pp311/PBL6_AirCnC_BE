﻿using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Application.Services.Properties.Specifications;
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
    Task<bool> IsStayedAsync(int propertyId);
}

public class PropertyService : IPropertyService
{
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Host> _hostRepository;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public PropertyService(IRepository<Property> propertyRepository, 
                           IUnitOfWork unitOfWork, IMapper mapper,
                           ICurrentUser currentUser,
                           IRepository<Host> hostRepository,
                           IRepository<Guest> guestRepository,
                           IRepository<Booking> bookingRepository)
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
        _hostRepository = hostRepository;
        _guestRepository = guestRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<PagedList<GetPropertyDto>> GetListByHostIdAsync(int hostId, PropertyQueryParameters pqp)
    {
        // t luoi nen dung lai cai spec nay
        var role = _currentUser.Role;
        var propertyFilterSpec = new PropertyFilterSpecification(pqp, role, hostId);

        var (items, totalCount) = await _propertyRepository.FindWithTotalCountAsync(propertyFilterSpec);
        var propertyList = items.ToList();

        var result = _mapper.Map<List<GetPropertyDto>>(items);
        
        var currentGuestId = 0;
        if (!string.IsNullOrWhiteSpace(_currentUser.Id))
            currentGuestId = (await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(int.Parse(_currentUser.Id))))!.Id;
        
        foreach (var item in result)
        {
            item.NumberOfReviews = propertyList.First(i => i.Id == item.Id).PropertyReviews.Count;
            if (item.NumberOfReviews == 0) continue;
            var property = propertyList.First(i => i.Id == item.Id);
            item.Rating = property.PropertyReviews
                .Average(r => (r.Accuracy + r.Communication + r.Cleanliness + r.Location + r.CheckIn + r.Value) / 6.0);
            item.IsFavorite  = propertyList.Any(i => i.Id == item.Id && i.Wishlists.Any(w => w.GuestId == currentGuestId));
        }

        return new PagedList<GetPropertyDto>(result, totalCount, pqp.PageIndex, pqp.PageSize);
    }

    public async Task<GetPropertyDto> GetByIdAsync(int id)
    {
        var propertyFilterSpec = new PropertyDetailSpecification(id);
        var property = await _propertyRepository.FindOneAsync(propertyFilterSpec)
                       ?? throw new EntityNotFoundException(nameof(Property), id.ToString());
        
        var result = _mapper.Map<GetPropertyDto>(property);
        result.NumberOfReviews = property.PropertyReviews.Count;
        if (result.NumberOfReviews == 0) return result;
        result.Rating = property.PropertyReviews
            .Average(r => (r.Accuracy + r.Communication + r.Cleanliness + r.Location + r.CheckIn + r.Value) / 6.0);
        
        if (string.IsNullOrWhiteSpace(_currentUser.Id)) return result;
        var currentGuestId = (await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(int.Parse(_currentUser.Id))))!.Id;
        result.IsFavorite = property.Wishlists.Any(w => w.GuestId == currentGuestId);
        return result;
    }

    public async Task<PagedList<GetPropertyDto>> GetListAsync(PropertyQueryParameters pqp)
    {
        var role = _currentUser.Role;
        var propertyFilterSpec = new PropertyFilterSpecification(pqp,role);

        var (items, totalCount) = await _propertyRepository.FindWithTotalCountAsync(propertyFilterSpec);
        
        var propertyList = items.ToList();

        var result = _mapper.Map<List<GetPropertyDto>>(propertyList);

        // Neu user da dang nhap thi moi check xem property co phai la favorite cua user hay khong
        var currentGuestId = 0;
        if (!string.IsNullOrWhiteSpace(_currentUser.Id))
        {
            var currentGuest = await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(int.Parse(_currentUser.Id)));
            if (currentGuest is not null)
                currentGuestId = currentGuest.Id;
            else
            {
                currentGuestId = 0;
            }                
        }

        foreach (var item in result)
        {
            item.NumberOfReviews = propertyList.First(i => i.Id == item.Id).PropertyReviews.Count;
            if (item.NumberOfReviews == 0) continue;
            var property = propertyList.First(i => i.Id == item.Id);
            item.Rating = property.PropertyReviews
                .Average(r => (r.Accuracy + r.Communication + r.Cleanliness + r.Location + r.CheckIn + r.Value) / 6.0);
            item.IsFavorite = propertyList.Any(i => i.Id == item.Id && i.Wishlists.Any(w => w.GuestId == currentGuestId));
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
            var paymentInfo = _mapper.Map<PaymentInfo>(upsertPropertyDto.PaymentInfo);
            host = new Host { UserId = userId ,PaymentInfo = paymentInfo};
            _hostRepository.Add(host);
        }

        // Create property as pending
        var property = _mapper.Map<Property>(upsertPropertyDto);
        var propertyUtilities = _mapper.Map<PropertyUtility>(upsertPropertyDto.PropertyUtilities);
        property.PropertyUtilities.Add(propertyUtilities);
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

    public async Task<bool> IsStayedAsync(int propertyId)
    {
        var currentUserId = int.TryParse(_currentUser.Id, out var id) ? id : 0;
        if (currentUserId == 0) return false;
        
        var guest = await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(currentUserId));
        if (guest is null) return false;

        var spec = new IsGuestStayedSpecification(propertyId, guest.Id);
        return await _bookingRepository.AnyAsync(spec);
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
        CreateMap<UpsertPropertyDto, Property>()
            .ForMember(p => p.PropertyUtilities, opt => opt.Ignore());
        CreateMap<UpsertPropertyImageDto, PropertyImage>();
        CreateMap<PropertyUtilityDto, PropertyUtility>();
    }
}
