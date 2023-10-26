using AirCnC.Domain.Specification;
using AirCnC.Domain.Entities;

namespace AirCnC.Application.Services.Wishlists.Specifications
{
    public class WishlistByGuestIdAndPropertyIdSpecification : Specification<Wishlist>
    {
        public WishlistByGuestIdAndPropertyIdSpecification(int guestId, int propertyId, bool isDeleted = false)
        {
            AddFilter(w => w.GuestId == guestId);
            AddFilter(w => w.PropertyId == propertyId);
            
            if (isDeleted)
                ApplyIgnoreQueryFilters();
        }
    }
}
