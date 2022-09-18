using System.Data.SqlClient;
using DataConrats.Infrastructure;

namespace DataAccessLayer;

public sealed class DbInitializer
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly List<string> _cities = new()
    {
        "Podolsk",
        "Moscow",
        "Archangelsk",
        "Checkhov",
        "Krasnoyarsk"
    };

    private readonly List<DateTime> _dates = new()
    {
        DateTime.Parse("2022.01.01"),
        DateTime.Parse("2022.02.01"),
        DateTime.Parse("2022.03.01"),
        DateTime.Parse("2022.04.01"),
        DateTime.Parse("2022.05.01"),
        DateTime.Parse("2022.06.01"),
        DateTime.Parse("2022.07.01"),
        DateTime.Parse("2022.08.01"),
        DateTime.Parse("2022.09.01"),
        DateTime.Parse("2022.10.01")
    };

    public DbInitializer(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public void Init()
    {
        using (SqlConnection connection = _connectionFactory.Create())
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [statistics].[prices]", connection);
            command.Connection.Open();
            int pricesCount = (int)command.ExecuteScalar();
            if (pricesCount == 0)
                FillDataSet(connection);
        }
    }

    private void FillDataSet(SqlConnection connection)
    {
        using (SqlTransaction transaction = connection.BeginTransaction())
        {
            Random random = new Random();
            try
            {
                foreach (string city in _cities)
                {
                    foreach (DateTime date in _dates)
                    {
                        for (int good = 0; good <= 8; good ++)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO [statistics].[prices] (registered_time, [value], city_of_registration, good_id)" + 
                                "VALUES(@time, @value, @city, @good);", 
                                connection);
                            command.Parameters.AddWithValue("@time", date);
                            command.Parameters.AddWithValue("@value", (decimal)random.Next(10, 1000));
                            command.Parameters.AddWithValue("@city", city);
                            command.Parameters.AddWithValue("@good", good);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
        }

    }
}