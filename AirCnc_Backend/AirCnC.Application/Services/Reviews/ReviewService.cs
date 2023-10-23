using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Reviews.Dtos;
using AirCnC.Application.Services.Reviews.Specifications;
using AirCnC.Domain.Constants;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AutoMapper;

namespace AirCnC.Application.Services.Reviews;

public interface IReviewService
{
    Task<PagedList<GetReviewDto>> GetHostReviewsAsync(int hostId, ReviewQueryParameters queryParameters);
    Task<PagedList<GetReviewDto>> GetGuestReviewsAsync(int guestId, ReviewQueryParameters queryParameters);
    Task<PagedList<GetPropertyReviewDto>> GetPropertyReviewsAsync(int propertyId, ReviewQueryParameters queryParameters);
    
    Task<GetReviewDto> CreateHostReviewAsync(int hostId, CreateReviewDto dto);
    Task<GetReviewDto> CreateGuestReviewAsync(int guestId, CreateReviewDto dto);
    Task<GetPropertyReviewDto> CreatePropertyReviewAsync(int propertyId, CreatePropertyReviewDto dto);
    
    Task DeleteHostReviewAsync(int hostReviewId);
    Task DeleteGuestReviewAsync(int guestReviewId);
    Task DeletePropertyReviewAsync(int propertyReviewId);
}

public class ReviewService : IReviewService
{
    private readonly IRepository<HostReview> _hostReviewRepository;
    private readonly IRepository<Host> _hostRepository;
    private readonly IRepository<GuestReview> _guestReviewRepository;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IRepository<PropertyReview> _propertyReviewRepository;
    private readonly IRepository<Property> _propertyRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReviewService(IRepository<HostReview> hostReviewRepository,
                         IRepository<GuestReview> guestReviewRepository,
                         IRepository<PropertyReview> propertyReviewRepository,
                         IUnitOfWork unitOfWork,
                         IMapper mapper,
                         IRepository<Property> propertyRepository,
                         IRepository<Guest> guestRepository,
                         IRepository<Host> hostRepository,
                         ICurrentUser currentUser)
    {
        _hostReviewRepository = hostReviewRepository;
        _guestReviewRepository = guestReviewRepository;
        _propertyReviewRepository = propertyReviewRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _propertyRepository = propertyRepository;
        _guestRepository = guestRepository;
        _hostRepository = hostRepository;
        _currentUser = currentUser;
    }


    public async Task<PagedList<GetReviewDto>> GetHostReviewsAsync(int hostId, ReviewQueryParameters qp)
    {
        var (hostReviews, totalCount) = await _hostReviewRepository
                                            .FindWithTotalCountAsync(new HostReviewSpecification(hostId, qp));
        
        var mappedHostReviews = _mapper.Map<IEnumerable<GetReviewDto>>(hostReviews);
        
        return new PagedList<GetReviewDto>(mappedHostReviews, totalCount, qp.PageIndex, qp.PageSize);
    }
    
    public async Task<PagedList<GetReviewDto>> GetGuestReviewsAsync(int guestId, ReviewQueryParameters qp)
    {
        var (guestReviews, totalCount) = await _guestReviewRepository
                                             .FindWithTotalCountAsync(new GuestReviewSpecification(guestId, qp));
        
        var mappedGuestReviews = _mapper.Map<IEnumerable<GetReviewDto>>(guestReviews);
        
        return new PagedList<GetReviewDto>(mappedGuestReviews, totalCount, qp.PageIndex, qp.PageSize);
    }

    public async Task<PagedList<GetPropertyReviewDto>> GetPropertyReviewsAsync(int propertyId,
                                                                         ReviewQueryParameters queryParameters)
    {
        var (propertyReviews, totalCount) = await _propertyReviewRepository
                                                 .FindWithTotalCountAsync(new PropertyReviewSpecification(propertyId,
                                                     queryParameters));
        
        var mappedPropertyReviews = _mapper.Map<IEnumerable<GetPropertyReviewDto>>(propertyReviews);
        
        return new PagedList<GetPropertyReviewDto>(mappedPropertyReviews, totalCount, queryParameters.PageIndex,
            queryParameters.PageSize);
    }

    public async Task<GetReviewDto> CreateHostReviewAsync(int hostId, CreateReviewDto dto)
    {
        dto.RevieweeId = hostId;
        dto.ReviewerId = int.Parse(_currentUser.Id!);
        
        // Todo: Check if guest has ever booked this host
        
        var isHostExist = await _hostRepository.AnyAsync(hostId);
        if (!isHostExist) throw new EntityNotFoundException(nameof(Host), hostId.ToString());
        
        var isGuestExist = await _guestRepository.AnyAsync(dto.ReviewerId);
        if (!isGuestExist) throw new EntityNotFoundException(nameof(Guest), dto.ReviewerId.ToString());
        
        var hostReview = await _hostReviewRepository.FindOneAsync(new HostReviewByIdsSpecification(hostId, dto.ReviewerId));
        
        // Update existing review or create new one
        if (hostReview != null) _mapper.Map(dto, hostReview);
        else
        {
            hostReview = _mapper.Map<HostReview>(dto);
            _hostReviewRepository.Add(hostReview);
        }
        
        await _unitOfWork.SaveChangesAsync();
        var reviewDto = _mapper.Map<GetReviewDto>(hostReview);
        reviewDto.ReviewerName = _currentUser.Name!;
        reviewDto.ReviewerAvatarUrl = _currentUser.AvatarUrl;
        return reviewDto;
    }

    public async Task<GetReviewDto> CreateGuestReviewAsync(int guestId, CreateReviewDto dto)
    {
        dto.RevieweeId = guestId;
        dto.ReviewerId = int.Parse(_currentUser.Id!);
        
        //Todo: Check if host has ever hosted this guest

        var host = await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(int.Parse(_currentUser.Id!)));
        if (host is null) throw new EntityNotFoundException(nameof(Host), dto.ReviewerId.ToString());
        
        var isGuestExist = await _guestRepository.AnyAsync(guestId);
        if (!isGuestExist) throw new EntityNotFoundException(nameof(Guest), guestId.ToString());
        
        var guestReview = await _guestReviewRepository.FindOneAsync(new GuestReviewByIdsSpecification(guestId, dto.ReviewerId));
        
        // Update existing review or create new one
        if (guestReview != null) _mapper.Map(dto, guestReview);
        else
        {
            guestReview = _mapper.Map<GuestReview>(dto);
            _guestReviewRepository.Add(guestReview);
        }
        
        await _unitOfWork.SaveChangesAsync();
        var reviewDto = _mapper.Map<GetReviewDto>(guestReview);
        reviewDto.ReviewerName = _currentUser.Name!;
        reviewDto.ReviewerAvatarUrl = _currentUser.AvatarUrl;
        return reviewDto;
    }

    public async Task<GetPropertyReviewDto> CreatePropertyReviewAsync(int propertyId, CreatePropertyReviewDto dto)
    {
        dto.PropertyId = propertyId;
        dto.GuestId = int.Parse(_currentUser.Id!);
        
        // Todo: Check if guest has ever booked this property
        
        var isPropertyExist = await _propertyRepository.AnyAsync(propertyId);
        if (!isPropertyExist) throw new EntityNotFoundException(nameof(Property), propertyId.ToString());
        
        var isGuestExist = await _guestRepository.AnyAsync(dto.GuestId);
        if (!isGuestExist) throw new EntityNotFoundException(nameof(Guest), dto.GuestId.ToString());
        
        var propertyReview = await _propertyReviewRepository.FindOneAsync(new PropertyReviewByIdsSpecification(propertyId, dto.GuestId));
        
        // Update existing review or create new one
        if (propertyReview != null) _mapper.Map(dto, propertyReview);
        else
        {
            propertyReview = _mapper.Map<PropertyReview>(dto);
            _propertyReviewRepository.Add(propertyReview);
        }
        
        await _unitOfWork.SaveChangesAsync();
        var reviewDto = _mapper.Map<GetPropertyReviewDto>(propertyReview);
        reviewDto.GuestName = _currentUser.Name!;
        reviewDto.GuestAvatarUrl = _currentUser.AvatarUrl;
        return reviewDto;
    }

    public async Task DeleteHostReviewAsync(int hostReviewId)
    {
        var hostReview = await _hostReviewRepository.GetByIdAsync(hostReviewId)
            ?? throw new EntityNotFoundException(nameof(HostReview), hostReviewId.ToString());
        
        // Check if user has permission to delete this review
        var currentUserId = int.Parse(_currentUser.Id!);
        var currentUserRole = _currentUser.Role!;

        if (currentUserRole != AppRole.Admin)
        {
            var guestId = (await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(currentUserId)))!.Id;
            if (hostReview.GuestId != guestId) throw new ForbiddenAccessException("You are not the owner of this review");
        }
        
        _hostReviewRepository.Delete(hostReview);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteGuestReviewAsync(int guestReviewId)
    {
        var guestReview = await _guestReviewRepository.GetByIdAsync(guestReviewId)
            ?? throw new EntityNotFoundException(nameof(GuestReview), guestReviewId.ToString());
        
        // Check if user has permission to delete this review
        var currentUserId = int.Parse(_currentUser.Id!);
        var currentUserRole = _currentUser.Role!;

        if (currentUserRole != AppRole.Admin)
        {
            var hostId = (await _hostRepository.FindOneAsync(new HostByUserIdSpecification(currentUserId)))!.Id;
            if (guestReview.HostId != hostId) throw new ForbiddenAccessException("You are not the owner of this review");
        }
        
        _guestReviewRepository.Delete(guestReview);
        await _unitOfWork.SaveChangesAsync(); 
    }

    public async Task DeletePropertyReviewAsync(int propertyReviewId)
    {
        var propertyReview = await _propertyReviewRepository.GetByIdAsync(propertyReviewId)
            ?? throw new EntityNotFoundException(nameof(PropertyReview), propertyReviewId.ToString());
        
        // Check if user has permission to delete this review
        var currentUserId = int.Parse(_currentUser.Id!);
        var currentUserRole = _currentUser.Role!;

        if (currentUserRole != AppRole.Admin)
        {
            var hostId = (await _hostRepository.FindOneAsync(new HostByUserIdSpecification(currentUserId)))!.Id;
            if (propertyReview.Property.HostId != hostId) throw new ForbiddenAccessException("You are not the owner of this review");
        }
        
        _propertyReviewRepository.Delete(propertyReview);
        await _unitOfWork.SaveChangesAsync();
    }
}

public class ReviewMapping : Profile
{
    public ReviewMapping()
    {
        CreateMap<HostReview, GetReviewDto>()
            .ForMember(dto => dto.ReviewerId, opt => opt.MapFrom(hr => hr.GuestId))
            .ForMember(dto => dto.ReviewerName, opt => opt.MapFrom(hr => hr.Guest.User.FullName))
            .ForMember(dto => dto.ReviewerAvatarUrl, opt => opt.MapFrom(hr => hr.Guest.User.AvatarUrl))
            .ForMember(dto => dto.ReviewTime, opt => opt.MapFrom(hr => hr.LastModifiedAt));

        CreateMap<GuestReview, GetReviewDto>()
            .ForMember(dto => dto.ReviewerId, opt => opt.MapFrom(hr => hr.HostId))
            .ForMember(dto => dto.ReviewerName, opt => opt.MapFrom(hr => hr.Host.User.FullName))
            .ForMember(dto => dto.ReviewerAvatarUrl, opt => opt.MapFrom(hr => hr.Host.User.AvatarUrl))
            .ForMember(dto => dto.ReviewTime, opt => opt.MapFrom(hr => hr.LastModifiedAt));
        
        CreateMap<PropertyReview, GetPropertyReviewDto>()
            .ForMember(dto => dto.GuestName, opt => opt.MapFrom(hr => hr.Guest.User.FullName))
            .ForMember(dto => dto.GuestAvatarUrl, opt => opt.MapFrom(hr => hr.Guest.User.AvatarUrl))
            .ForMember(dto => dto.ReviewTime, opt => opt.MapFrom(hr => hr.LastModifiedAt))
            .ForMember(dto => dto.AverageRating, opt => opt
                .MapFrom(hr => ((double)(hr.Cleanliness + hr.Communication + hr.CheckIn + hr.Accuracy + hr.Location + hr.Value)) / 6));
        
        CreateMap<CreateReviewDto, HostReview>()
            .ForMember(hr => hr.HostId, opt => opt.MapFrom(dto => dto.RevieweeId))
            .ForMember(hr => hr.GuestId, opt => opt.MapFrom(dto => dto.ReviewerId));

        CreateMap<CreateReviewDto, GuestReview>()
            .ForMember(hr => hr.GuestId, opt => opt.MapFrom(dto => dto.RevieweeId))
            .ForMember(hr => hr.HostId, opt => opt.MapFrom(dto => dto.ReviewerId));
        
        CreateMap<CreatePropertyReviewDto, PropertyReview>();
    }
}