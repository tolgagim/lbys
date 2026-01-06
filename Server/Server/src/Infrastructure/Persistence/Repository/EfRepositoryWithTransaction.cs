using Server.Application.Common.Persistence;
using Server.Domain.Common.Contracts;
using Server.Infrastructure.Persistence.Context;

namespace Server.Infrastructure.Persistence.Repository;
public class EfRepositoryWithTransaction<T> : ApplicationDbRepository<T>, IRepositoryWithTransaction<T> where T : class, IAggregateRoot
{
    private readonly ApplicationDbContext _dbContext;

    public EfRepositoryWithTransaction(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BeginTransactionAsync()
    {
        await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
}
