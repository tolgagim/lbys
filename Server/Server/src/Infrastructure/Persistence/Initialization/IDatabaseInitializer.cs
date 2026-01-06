namespace Server.Infrastructure.Persistence.Initialization;
public interface IDatabaseInitializer
{
    Task InitializeDatabasesAsync(CancellationToken cancellationToken);
}
