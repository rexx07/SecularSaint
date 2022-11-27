using System.Collections.ObjectModel;

namespace SS.Shared.Authorization;

public static class SSRoles
{
    public const string Superuser = nameof(Superuser);
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
    {
        Superuser,
        Admin,
        Basic
    });

    public static bool IsDefault(string? roleName)
    {
        return DefaultRoles.Any(r => r == roleName);
    }
}