using System.Reflection;
using System.Runtime.CompilerServices;
using AspNetCoreRateLimit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SS.Infrastructure.Caching;
using SS.Infrastructure.Common;
using SS.Infrastructure.Cors;
using SS.Infrastructure.FileStorage;
using SS.Infrastructure.Localization;
using SS.Infrastructure.Mailing;
using SS.Infrastructure.Middleware;
using SS.Infrastructure.Notifications;
using SS.Infrastructure.Persistence;
using SS.Infrastructure.SecurityHeaders;

[assembly: InternalsVisibleTo("Infrastructure.Test")]

namespace SS.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddApiVersioning()
            .AddCaching(config)
            .AddRateLimitingOptions()
            .AddCorsPolicy(config)
            .AddExceptionMiddleware()
            .AddHealthCheck()
            .AddPOLocalization(config)
            .AddMailing(config)
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddNotifications(config)
            .AddPersistence(config)
            .AddRequestLogging(config)
            .AddRouting(options => options.LowercaseUrls = true)
            .AddServices();
    }

    private static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
        return services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
    }

    private static IServiceCollection AddHealthCheck(this IServiceCollection services)
    {
        return services.AddHealthChecks().AddCheck<AppHealthCheck>("WebApp").Services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config)
    {
        return builder
            .UseRequestLocalization()
            .UseStaticFiles()
            .UseSecurityHeaders(config)
            .UseFileStorage()
            .UseExceptionMiddleware()
            .UseRouting()
            .UseStaticFiles()
            .UseHttpsRedirection()
            .UseIpRateLimiting()
            .UseCorsPolicy()
            .UseCaching()
            .UseHttpCacheHeaders()
            .UseRequestLogging(config);
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapControllers().RequireAuthorization();
        builder.MapHealthChecks();
        return builder;
    }

    public static IEndpointConventionBuilder MapHealthChecks(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapHealthChecks("/api/health").RequireAuthorization();
    }

    public static IServiceCollection AddRateLimitingOptions(this IServiceCollection services)
    {
        var rateLimitRules = new List<RateLimitRule>
        {
            new()
            {
                Endpoint = "*",
                Limit = 30,
                Period = "5m"
            }
        };

        services.Configure<IpRateLimitOptions>(opt => { opt.GeneralRules = rateLimitRules; });
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

        return services;
    }
}

public class AppHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        // Descoped
        var check = new HealthCheckResult(HealthStatus.Healthy);
        return Task.FromResult(check);
    }
}