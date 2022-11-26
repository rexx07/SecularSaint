using SS.Application.Interfaces.Common;

namespace SS.Application.Caching;

public interface ICacheKeyService : IScopedService
{
    public string GetCacheKey(string name, object id, bool includeCurrentUserId = true);
}