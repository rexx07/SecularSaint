using Microsoft.Extensions.Options;
using Npgsql;
using SS.Application.Interfaces.Persistence;
using SS.Infrastructure.Common;
using SS.Infrastructure.Persistence;

namespace SS.Infrastructure.ConnectionString;

public class ConnectionStringSecurer : IConnectionStringSecurer
{
    private const string HiddenValueDefault = "*******";
    private readonly DatabaseSettings _dbSettings;

    public ConnectionStringSecurer(IOptions<DatabaseSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public string? MakeSecure(string? connectionString, string? dbProvider)
    {
        if (connectionString == null || string.IsNullOrEmpty(connectionString)) return connectionString;

        if (string.IsNullOrWhiteSpace(dbProvider)) dbProvider = _dbSettings.DBProvider;

        return dbProvider?.ToLower() switch
        {
            DbProviderKeys.Npgsql => MakeSecureNpgsqlConnectionString(connectionString),

            _ => connectionString
        };
    }

    private string MakeSecureNpgsqlConnectionString(string connectionString)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);

        if (!string.IsNullOrEmpty(builder.Password) || !builder.IntegratedSecurity)
            builder.Password = HiddenValueDefault;

        if (!string.IsNullOrEmpty(builder.Username) || !builder.IntegratedSecurity)
            builder.Username = HiddenValueDefault;

        return builder.ToString();
    }
}