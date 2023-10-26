using AirCnC.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCnC.Domain.Entities;

namespace AirCnC.Application.Services.Wishlists.Specifications
{
    public class WishlistByGuestIdAndProperTyIDSpecification: Specification<Wishlist>
    {
        public WishlistByGuestIdAndProperTyIDSpecification(int guestId,int propertyId)
        {
            AddFilter(w => w.GuestId == guestId);
            AddFilter(w=>w.PropertyId== propertyId);
        }
    }
}
