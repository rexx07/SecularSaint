using SS.Application.Caching;
using SS.Application.Interfaces.Common;

namespace SS.Infrastructure.Caching;

public class CacheKeyService : ICacheKeyService
{
    private readonly ICurrentUser? _currentUser;

    public CacheKeyService(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public string GetCacheKey(string name, object id, bool includeCurrentUserId = true)
    {
        var currentUserId = includeCurrentUserId
            ? _currentUser?.GetUserId().ToString() ??
              throw new InvalidOperationException(
                  "GetCacheKey: includeTenantId set to true and no ITenantInfo available.")
            : "GLOBAL";
        return $"{currentUserId}-{name}-{id}";
    }
}