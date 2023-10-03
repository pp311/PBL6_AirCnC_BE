using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Enums.Sorting;
using AirCnC.Domain.Data;

namespace AirCnC.Domain.Repositories
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<(IEnumerable<Property> Items, int TotalCount)> GetPropertyPagedListAsync(string? search,
                                                                                    PropertyType? type,
                                                                                    PropertySortBy? orderBy,
                                                                                    int skip,
                                                                                    int take,
                                                                                    bool isDescending);
        //Task<bool> IsProductCodeExistAsync(string productCode, int productId = 0);
        //Task<bool> IsProductExistAsync(int productId);
    }
}
