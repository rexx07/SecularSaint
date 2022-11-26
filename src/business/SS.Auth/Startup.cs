using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SS.Application.Interfaces.Common;
using SS.Application.Interfaces.Service.User;
using SS.Auth.Jwt;
using SS.Auth.Permissions;
using SS.Auth.Services;
using SS.Domain.Auth;
using SS.Domain.Users;
using SS.Infrastructure.Persistence.Context;
using SS.Infrastructure.SecurityHeaders;

namespace SS.Auth;

public static class Startup
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddCurrentUser()
            .AddPermissions()

            // Must add identity before adding auth!
            .AddIdentity()
            .AddServices();
        services.Configure<SecuritySettings>(config.GetSection(nameof(SecuritySettings)));
        return services.AddJwtAuth(config);
    }

    public static IApplicationBuilder UseAuth(this IApplicationBuilder builder)
    {
        return builder
            .UseAuthentication()
            .UseMiddleware<CurrentUserMiddleware>()
            .UseAuthorization();
    }

    private static IServiceCollection AddCurrentUser(this IServiceCollection services)
    {
        return services
            .AddScoped<CurrentUserMiddleware>()
            .AddScoped<ICurrentUser, CurrentUser>()
            .AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());
    }

    private static IServiceCollection AddPermissions(this IServiceCollection services)
    {
        return services
            .AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
            .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
    }

    internal static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        return services
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .Services;
    }
}