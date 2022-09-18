using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer;

public sealed class DbInitializer
{
    private readonly string _connectionString;
    
    public DbInitializer(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("StatisticsDbConnectionString");
    }

    public void Init()
    {
        
    }
}