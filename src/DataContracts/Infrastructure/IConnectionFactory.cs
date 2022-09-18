using System.Data.SqlClient;

namespace DataConrats.Infrastructure;

public interface IConnectionFactory
{
    SqlConnection Create();
}