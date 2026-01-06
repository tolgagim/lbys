using Server.Application.Common.Caching;

namespace Server.Infrastructure.Caching;
public class CacheKeyService : ICacheKeyService
{
    public string GetCacheKey(string name, object id)
    {
        return $"GLOBAL-{name}-{id}";
    }
}
