using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using SS.Application.Interfaces.Persistence;
using SS.Infrastructure.Common;
using SS.Infrastructure.Persistence;

namespace SS.Infrastructure.ConnectionString;

internal class ConnectionStringValidator : IConnectionStringValidator
{
    private readonly DatabaseSettings _dbSettings;
    private readonly ILogger<ConnectionStringValidator> _logger;

    public ConnectionStringValidator(IOptions<DatabaseSettings> dbSettings, ILogger<ConnectionStringValidator> logger)
    {
        _dbSettings = dbSettings.Value;
        _logger = logger;
    }

    public bool TryValidate(string connectionString, string? dbProvider = null)
    {
        if (string.IsNullOrWhiteSpace(dbProvider)) dbProvider = _dbSettings.DBProvider;

        try
        {
            switch (dbProvider?.ToLowerInvariant())
            {
                case DbProviderKeys.Npgsql:
                    var postgresqlcs = new NpgsqlConnectionStringBuilder(connectionString);
                    break;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Connection String Validation Exception : {ex.Message}");
            return false;
        }
    }
}