using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.CheckIn.Specifications
{
    public class BookingByGuidSpecification: Specification<Booking>
    {
        public BookingByGuidSpecification(string code)
        {
            AddInclude(b => b.Property);
            AddInclude(b => b.Guest);
            AddInclude(b => b.Guest.User);
            AddInclude(b => b.Property.Host);
            AddFilter(b => b.Guid == code);
        }
    }
}
