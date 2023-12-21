
using HC.Application.Common.Persistence;
using Microsoft.Extensions.Options;
using Npgsql;

namespace HC.Infrastructure.Persistence.ConnectionString;

public class ConnectionStringSecurer : IConnectionStringSecurer
{
    private const string HiddenValueDefault = "*******";

    public string? MakeSecure(string? connectionString)
    {
        if (connectionString == null || string.IsNullOrEmpty(connectionString))
        {
            return connectionString;
        }
        return MakeSecureNpgsqlConnectionString(connectionString);
    }
    private static string MakeSecureNpgsqlConnectionString(string connectionString)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);

        if (!string.IsNullOrEmpty(builder.Password) || !builder.IntegratedSecurity)
        {
            builder.Password = HiddenValueDefault;
        }

        if (!string.IsNullOrEmpty(builder.Username) || !builder.IntegratedSecurity)
        {
            builder.Username = HiddenValueDefault;
        }

        return builder.ToString();
    }
}