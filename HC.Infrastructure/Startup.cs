using HC.BE.Infrastructure.Caching;
using HC.BE.Infrastructure.Middleware;
using HC.Infrastructure.Common;
using HC.Infrastructure.Cors;
using HC.Infrastructure.Mapping;
using HC.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HC.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        MapsterSettings.Configure();
        return services
            .AddAuth(config)
            .AddCaching(config)
            .AddCorsPolicy(config)
            .AddExceptionMiddleware()
            .AddPersistence()
            .AddRequestLogging(config)
            .AddRouting(options => options.LowercaseUrls = true)
            .AddServices();
    }


    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            .UseRequestLocalization()
            .UseStaticFiles()
            .UseExceptionMiddleware()
            .UseRouting()
            .UseCorsPolicy()
            .UseAuthentication()
            .UseCurrentUser()
            .UseAuthorization()
            .UseRequestLogging(config);

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapControllers().RequireAuthorization();
        return builder;
    }
}