using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace HC.API.Configuration
{
    public static class ConfigureFirebase
    {
        public static void AddFirebase(this IServiceCollection services)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(AppConfig.FirebaseConfig.Path)
            });
        }
    }
}
