using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Guests.Specifications;

public class GuestDetailSpecification : Specification<Guest>
{
    public GuestDetailSpecification(int id)
    {
        AddInclude(guest => guest.User);
        AddFilter(guest => guest.Id == id);
    } 
}