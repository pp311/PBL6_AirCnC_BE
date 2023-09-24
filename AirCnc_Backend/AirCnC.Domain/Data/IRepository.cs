using AirCnC.Domain.Specification;

namespace AirCnC.Domain.Data
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id, bool isNoTracking = false);
        Task<IEnumerable<T>> GetAllAsync();
        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
        Task<T?> FindOneAsync(ISpecification<T> spec);
        Task<IEnumerable<T>> FindListAsync(ISpecification<T> spec);
        
        Task<int> CountAsync(ISpecification<T> spec);
        Task<bool> AnyAsync(ISpecification<T> spec);
        Task<bool> AnyAsync(int id);
        
        Task<(IEnumerable<T>, int)> FindWithTotalCountAsync(ISpecification<T> specification);
    }
}
