using Microsoft.Extensions.DependencyInjection;

namespace HC.Infrastructure.Storage;

internal static class Startup
{
    public static IServiceCollection AddStorage(this IServiceCollection services)
    {
        services.AddOptions<AwsSettings>()
            .BindConfiguration("AwsCredentials")
            .ValidateDataAnnotations();
        services.AddSingleton<StorageService>();
        return services;
    }
}