using System.Data;
using CrudOpreations.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace CrudOpreations.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
}   
public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(IOptionsMonitor<CrudSettings> configurations) => 
        _connectionString = configurations.CurrentValue.ConnectionString;

    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        return connection;
    }
}
