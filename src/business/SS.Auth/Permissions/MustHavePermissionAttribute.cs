using Microsoft.AspNetCore.Authorization;
using SS.Shared.Authorization;

namespace SS.Auth.Permissions;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string action, string resource)
    {
        Policy = SSPermission.NameFor(action, resource);
    }
}