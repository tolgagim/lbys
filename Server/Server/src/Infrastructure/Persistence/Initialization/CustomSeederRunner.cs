using Microsoft.Extensions.DependencyInjection;

namespace Server.Infrastructure.Persistence.Initialization;
internal class CustomSeederRunner
{
    private readonly IEnumerable<ICustomSeeder> _seeders;

    public CustomSeederRunner(IEnumerable<ICustomSeeder> seeders) =>
        _seeders = seeders;

    public async Task RunSeedersAsync(CancellationToken cancellationToken)
    {
        foreach (var seeder in _seeders)
        {
            await seeder.InitializeAsync(cancellationToken);
        }
    }
}