using System.Threading.Tasks;
namespace Server.Application.Common.Persistence;
public interface IRepositoryWithTransaction<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}