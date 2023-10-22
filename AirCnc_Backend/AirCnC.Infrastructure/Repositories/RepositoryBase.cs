using System.Linq.Expressions;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities.Base;
using AirCnC.Domain.Specification;
using AirCnC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.Infrastructure.Repositories;

public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private DbSet<TEntity>? _dbSet;
    protected DbSet<TEntity> DbSet => _dbSet ??= _dbContext.Set<TEntity>();
    
    private readonly AirCnCDbContext _dbContext;
    
    public RepositoryBase(AirCnCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(int id, bool isNoTracking = false)
    {
        var query = DbSet.AsQueryable();
        if (isNoTracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(e => e.Id == id); 
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSet.AsNoTracking().ToListAsync(); 

    public void Add(TEntity entity) => DbSet.Add(entity);

    public void Update(TEntity entity) => DbSet.Update(entity);

    public void Delete(TEntity entity) => entity.IsDeleted = true;

    public async Task<TEntity?> FindOneAsync(ISpecification<TEntity> spec) 
        => await GetQuery<TEntity>.From(DbSet, spec).FirstOrDefaultAsync();

    public async Task<IEnumerable<TEntity>> FindListAsync(ISpecification<TEntity> spec)
        => await GetQuery<TEntity>.From(DbSet, spec).ToListAsync();

    public async Task<int> CountAsync(ISpecification<TEntity> spec)
        => await GetQuery<TEntity>.From(DbSet, spec).CountAsync();

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        => await DbSet.CountAsync(predicate);
    
    // public async Task<double> AverageAsync(ISpecification<TEntity> spec, Expression<Func<TEntity, int>> selector)
    //     => await GetQuery<TEntity>.From(DbSet, spec).AverageAsync(selector);

    public async Task<double> AverageAsync(ISpecification<TEntity> spec, Expression<Func<TEntity, double>> selector)
        => await GetQuery<TEntity>.From(DbSet, spec).AverageAsync(selector);

    public async Task<bool> AnyAsync(ISpecification<TEntity> spec)
        => await GetQuery<TEntity>.From(DbSet, spec).AnyAsync();

    public async Task<bool> AnyAsync(int id)
        => await DbSet.AnyAsync(e => e.Id == id);

    public async Task<(IEnumerable<TEntity>, int)> FindWithTotalCountAsync(ISpecification<TEntity> specification)
    {
        var query = GetQuery<TEntity>.From(DbSet, specification);
        var count = await query.CountAsync();
        var data = await query.Skip(specification.Skip).Take(specification.Take).ToListAsync();
        return (data, count);
    }
}