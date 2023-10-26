using AirCnC.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCnC.Domain.Entities;
using AirCnC.Application.Commons;

namespace AirCnC.Application.Services.Wishlists.Specifications
{
    public class WishlistByGuestIdSpecification: Specification<Wishlist>
    {
        public WishlistByGuestIdSpecification(PagingParameters pg, int guestId)
        {
            AddFilter(w => w.GuestId == guestId);
            AddInclude(w => w.Property);
            AddInclude(w => w.Property.PropertyImages);
            AddInclude(w => w.Property.PropertyUtilities);
            AddInclude(w => w.Property.PropertyReviews);
            AddInclude(w => w.Property.Host.User);
            ApplyPaging(pageIndex: pg.PageIndex, pageSize: pg.PageSize);
        }
    }
}
