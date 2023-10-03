using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Enums.Sorting;

using AirCnC.Infrastructure.Data;
using AirCnC.Domain.Specification;
using AirCnC.Domain.Specification.Property;
using Microsoft.EntityFrameworkCore;
using AirCnC.Domain.Repositories;

namespace AirCnC.Infrastructure.Repositories
{
    public class PropertyRepository : RepositoryBase<Property>,IPropertyRepository
    {
        public PropertyRepository(AirCnCDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<(IEnumerable<Property> Items,int TotalCount)> GetPropertyPagedListAsync(string? search,
                                                                                    PropertyType? type,
                                                                                    PropertySortBy? orderBy,
                                                                                    int skip,
                                                                                    int take,
                                                                                    bool isDescending) 
        {
            var query = SpecificationEvaluator<Property>.GetQuery(
                query: DbSet.AsNoTracking(),
                specification: new PropertyFilterSpecification(search, type, orderBy, isDescending));
            var totalCount = await query.CountAsync();

            // If skip and take provided, apply them 
            if (skip >= 0 && take > 0)
                query = query.Skip(skip).Take(take);

            return (await query.ToListAsync(), totalCount);
        }
    }
}
