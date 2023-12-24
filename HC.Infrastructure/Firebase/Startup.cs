using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HC.Infrastructure.Firebase;

internal static class Startup
{
    internal static IServiceCollection AddFirebase(this IServiceCollection services)
    {
        services.AddOptions<FirebaseSetting>()
            .BindConfiguration($"FirebaseSettings")
            .ValidateDataAnnotations();

        services.AddSingleton(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<FirebaseSetting>>().Value;
            return FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(settings.Path)
            });
        });

        return services;
    }
}

