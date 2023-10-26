using AirCnC.Application.Commons;
using AirCnC.Application.Services.Properties.Dtos;
using AirCnC.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCnC.Domain.Entities;

using AirCnC.Application.Commons.Identity;
using AutoMapper;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Wishlists.Dtos;
using AirCnC.Application.Services.Wishlists.Specifications;
using AirCnC.Domain.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Wishlists
{
    public interface IWishlistService
    {
        Task<PagedList<WishlistsDto>> GetListAsync(PagingParameters pg);
        Task AddWishlistAsync(int propertyId);
        Task RemoveWishlistItemByIdAsync(int propertyId);
    }    
    public class WishlistService: IWishlistService
    {

        private readonly IRepository<Wishlist> _wishlistRepository;
        private readonly IRepository<Guest> _GuestRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public WishlistService(IUnitOfWork unitOfWork, IMapper mapper,
            ICurrentUser currentUser, IRepository<Wishlist> wishlistRepository,
            IRepository<Guest> guestRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
            _wishlistRepository = wishlistRepository;
            _GuestRepository = guestRepository;
        }
        public async Task<PagedList<WishlistsDto>> GetListAsync(PagingParameters pg)
        {
            var guest = await GetGuest(int.Parse(_currentUser.Id!));
            var specification = new WishlistByGuestIdSpecification(pg,guest.Id);
            var(items, totalCount) = await _wishlistRepository.FindWithTotalCountAsync(specification);
            var result = _mapper.Map<List<WishlistsDto>>(items);
            return new PagedList<WishlistsDto>(result, totalCount, pg.PageIndex, pg.PageSize);
        }

        public async Task AddWishlistAsync(int propertyId)
        {
            var guest = await GetGuest(int.Parse(_currentUser.Id!));
            var specification= new WishlistByGuestIdAndProperTyIDSpecification(guest.Id,propertyId);
            var wishlist = await _wishlistRepository.FindOneAsync(specification);
            if (wishlist is null)
            {
                var newWishlist = new Wishlist()
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
            var specification = new WishlistByGuestIdAndProperTyIDSpecification(guest.Id, propertyId);
            var wishlist = await _wishlistRepository.FindOneAsync(specification);
            if (wishlist is not null)
            {
                _wishlistRepository.Delete(wishlist);
                await _unitOfWork.SaveChangesAsync();
            }
            throw new EntityNotFoundException(nameof(Wishlist), propertyId.ToString()+" userID:"+_currentUser.Id);
        }

        public async Task<Guest> GetGuest(int userId)
        {
            var Specification= new GuestByUserIdSpecification(userId);
            var guest = await _GuestRepository.FindOneAsync(Specification);
            if (guest is null)
                throw new EntityNotFoundException(nameof(Guest), userId.ToString());
            return guest;
        }
    }
}
