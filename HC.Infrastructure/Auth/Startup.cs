using HC.Application.Common.Interfaces;
using HC.Infrastructure.Auth;
using HC.Infrastructure.Auth.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class Startup
{
    internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        // return services
        // .AddCurrentUser()
        // .AddJwtAuth();
        services.Configure<SecuritySettings>(config.GetSection(nameof(SecuritySettings)));
        return services
            .AddJwtAuth()
            .AddCurrentUser();


    }

    internal static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) =>
        app.UseMiddleware<CurrentUserMiddleware>();

    private static IServiceCollection AddCurrentUser(this IServiceCollection services) =>
        services
            .AddScoped<CurrentUserMiddleware>()
            .AddScoped<ICurrentUser, CurrentUser>()
            .AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());

}