using Microsoft.AspNetCore.Identity;

namespace SS.Domain.Auth;

public class ApplicationRole : IdentityRole<string>
{
    public ApplicationRole(string name, string? description = null)
        : base(name)
    {
        Description = description;
        NormalizedName = name.ToUpperInvariant();
    }

    public string? Description { get; set; }
}