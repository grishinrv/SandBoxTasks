using System.Data.SqlClient;

namespace DataContracts.Infrastructure;

public interface IConnectionFactory
{
    SqlConnection Create();
}