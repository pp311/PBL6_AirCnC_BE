using AirCnC.Application.Commons;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Application.Commons.Identity;
using AutoMapper;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Application.Services.Properties.Specifications;
using AirCnC.Application.Services.Wishlists.Dtos;
using AirCnC.Application.Services.Wishlists.Specifications;
using AirCnC.Domain.Exceptions;

namespace AirCnC.Application.Services.Wishlists;
    
public interface IWishlistService
{
    Task<PagedList<GetPropertyDto>> GetListAsync(PagingParameters pg);
    Task AddWishlistAsync(int propertyId);
    Task RemoveWishlistItemByIdAsync(int propertyId);
}    

public class WishlistService : IWishlistService
{

    private readonly IRepository<Wishlist> _wishlistRepository;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IRepository<Property> _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;

    public WishlistService(IUnitOfWork unitOfWork, IMapper mapper,
        ICurrentUser currentUser, IRepository<Wishlist> wishlistRepository,
        IRepository<Guest> guestRepository, IRepository<Property> propertyRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
        _wishlistRepository = wishlistRepository;
        _guestRepository = guestRepository;
        _propertyRepository = propertyRepository;

    }
    
    public async Task<PagedList<GetPropertyDto>> GetListAsync(PagingParameters pg)
    {
        var guest = await GetGuest(int.Parse(_currentUser.Id!));
        var specification = new WishlistByGuestIdSpecification(pg,guest.Id);
        var items = await _wishlistRepository.FindListAsync(specification);
        
        var propertySpecification = new PropertiesByIdsSpecification(items.Select(w => w.PropertyId).ToList(), pg.PageIndex, pg.PageSize);
        var (properties, totalCount) = await _propertyRepository.FindWithTotalCountAsync(propertySpecification);
        
        var result = _mapper.Map<List<GetPropertyDto>>(properties);
        result.ForEach(item => item.IsFavorite = true);
        return new PagedList<GetPropertyDto>(result, totalCount, pg.PageIndex, pg.PageSize);
    }

    public async Task AddWishlistAsync(int propertyId)
    {
        var guest = await GetGuest(int.Parse(_currentUser.Id!));
        var property = await _propertyRepository.GetByIdAsync(propertyId);
        if (property is null)
            throw new EntityNotFoundException(nameof(Property), propertyId.ToString());

        var specification = new WishlistByGuestIdAndPropertyIdSpecification(guest.Id, propertyId, true);
        var wishlist = await _wishlistRepository.FindOneAsync(specification);
        
        if (wishlist is null)
        {
            var newWishlist = new Wishlist
            {
                GuestId = guest.Id,
                PropertyId = propertyId
            };
            _wishlistRepository.Add(newWishlist);
            await _unitOfWork.SaveChangesAsync();
            return;
        }
        
        wishlist.IsDeleted = false;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveWishlistItemByIdAsync(int propertyId)
    {
        var guest = await GetGuest(int.Parse(_currentUser.Id!));
        var specification = new WishlistByGuestIdAndPropertyIdSpecification(guest.Id, propertyId);
        var wishlist = await _wishlistRepository.FindOneAsync(specification)
                       ?? throw new EntityNotFoundException( "Wishlist item", $"property: {propertyId} - userId: {_currentUser.Id}");
        
        _wishlistRepository.Delete(wishlist);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<Guest> GetGuest(int userId)
    {
        var specification = new GuestByUserIdSpecification(userId);
        var guest = await _guestRepository.FindOneAsync(specification);
        if (guest is null)
            throw new EntityNotFoundException(nameof(Guest), userId.ToString());
        return guest;
    }
}
