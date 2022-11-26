using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Serilog;
using SS.Application;
using SS.Auth;
using SS.Infrastructure;
using SS.Infrastructure.Common;
using SS.Web.Configurations;

StaticLogger.EnsureInitialized();
Log.Information("Server booting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();

    builder.Host.UseSerilog((_, config) =>
    {
        config.WriteTo.Console()
            .ReadFrom.Configuration(builder.Configuration);
    });
    
    // Add services to the container.
    builder.Services.AddControllersWithViews(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
        config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
        config.CacheProfiles.Add("120SecondsDuration", new CacheProfile { Duration = 120 });
    });
    
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddAuth(builder.Configuration);
    builder.Services.AddApplication();

    var app = builder.Build();
        
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseInfrastructure(builder.Configuration);
    app.UseAuth();
        
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
        
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
{
    return new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
        .Services.BuildServiceProvider()
        .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
        .OfType<NewtonsoftJsonPatchInputFormatter>().First();
}






