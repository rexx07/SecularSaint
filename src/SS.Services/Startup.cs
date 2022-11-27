using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SS.Services.Auth;

namespace SS.Services;

public static class Startup
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddAuth(config)
            .AddServices();
    }

    public static IApplicationBuilder UseServices(this IApplicationBuilder builder)
    {
        return builder
            .UseAuthentication()
            .UseAuthorization();
    }
}