using System.Data.SqlClient;
using DataConrats.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace DataContracts.Infrastructure;

public sealed class ConnectionFactory : IConnectionFactory
{
    private readonly string _connectionString;
    
    public ConnectionFactory(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("StatisticsDbConnectionString");
    }
    
    public SqlConnection Create() => new (_connectionString);
}