using HC.Application.Common.Persistence;
using HC.BE.Infrastructure.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;

namespace HC.Infrastructure.Persistence.ConnectionString;

internal class ConnectionStringValidator : IConnectionStringValidator
{
    private readonly ILogger<ConnectionStringValidator> _logger;

    public ConnectionStringValidator(ILogger<ConnectionStringValidator> logger)
    {
        _logger = logger;
    }

    public bool TryValidate(string connectionString)
    {

        try
        {
            _ = new NpgsqlConnectionStringBuilder(connectionString);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Connection String Validation Exception : {ex.Message}");
            return false;
        }
    }
}