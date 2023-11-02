using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.CheckIn.Specifications
{
    public class BookingByGuidSpecification: Specification<Booking>
    {
        public BookingByGuidSpecification(string Guid)
        {
            AddInclude(b=>b.Property);
            AddInclude(b=>b.Guest);
            AddFilter(b=>b.Guid==Guid);
        }
    }
}
