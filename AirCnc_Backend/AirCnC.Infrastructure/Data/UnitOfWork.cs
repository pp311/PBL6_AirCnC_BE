using AirCnC.Domain.Data;

namespace AirCnC.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AirCnCDbContext _context;

    public UnitOfWork(AirCnCDbContext context)
    {
        _context = context;
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.BeginTransactionAsync(cancellationToken);
    }
}