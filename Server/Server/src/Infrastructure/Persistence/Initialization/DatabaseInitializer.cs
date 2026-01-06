using Microsoft.Extensions.Logging;

namespace Server.Infrastructure.Persistence.Initialization;
internal class DatabaseInitializer : IDatabaseInitializer
{
    private readonly ApplicationDbInitializer _dbInitializer;
    private readonly ILogger<DatabaseInitializer> _logger;

    public DatabaseInitializer(ApplicationDbInitializer dbInitializer, ILogger<DatabaseInitializer> logger)
    {
        _dbInitializer = dbInitializer;
        _logger = logger;
    }

    public async Task InitializeDatabasesAsync(CancellationToken cancellationToken)
    {
        await _dbInitializer.InitializeAsync(cancellationToken);

        _logger.LogInformation("For documentations and guides, visit https://www.fullstackhero.net");
        _logger.LogInformation("To Sponsor this project, visit https://opencollective.com/fullstackhero");
    }
}
