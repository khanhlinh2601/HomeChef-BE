using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HC.Infrastructure.Firebase;

internal static class Startup
{
    internal static IServiceCollection AddFirebase(this IServiceCollection services, IConfiguration configuration)
    {
        var firebaseSettings = configuration.GetSection(nameof(FirebaseSetting)).Get<FirebaseSetting>();
        if (firebaseSettings == null) return services;
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile(firebaseSettings.Path)
        });

        return services;
    }
}

