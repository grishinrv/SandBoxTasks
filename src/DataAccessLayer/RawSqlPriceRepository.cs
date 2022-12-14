using DataConrats.Model;
using DataContracts.Infrastructure;
using System.Data.SqlClient;

namespace DataAccessLayer;

public class RawSqlPriceRepository : IPriceRepository
{
    private readonly IConnectionFactory _connectionFactory;
    public RawSqlPriceRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public void CreatePriceData(PriceData dto)
    {
        using (SqlConnection connection = _connectionFactory.Create())
        {
            try
            {
                string sql = "INSERT INTO [statistics].prices (good_id, good_name, [value], city_of_registration, registered_time) " +
                             "VALUES (@name, @price, @city, @date)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", dto.GoodItem.ToString());
                command.Parameters.AddWithValue("@price", dto.Value);
                command.Parameters.AddWithValue("@city", dto.CityOfRegistration);
                command.Parameters.AddWithValue("@date", dto.RegisteredTime);
                command.Connection.Open();

                int numberOfInsertedRows = command.ExecuteNonQuery();
                if (numberOfInsertedRows != 1)
                {
                    throw new ApplicationException($"Danger! inserted {numberOfInsertedRows} rows!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public List<PriceData> GetPricesData(string cityOfPriceRegistration)
    {
        using (SqlConnection connection = _connectionFactory.Create())
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [statistics].[prices] WHERE [city_of_registration] = @city", connection);
                command.Parameters.AddWithValue("@city", cityOfPriceRegistration);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<PriceData> results = new();
                while (reader.Read())
                {
                    DateTime time = (DateTime)reader["registered_time"];
                    string city = (string)reader["city_of_registration"];
                    decimal val = (decimal)reader["value"];
                    Good good = (Good)(int)reader["good_id"];
                    results.Add(new PriceData
                    {
                        RegisteredTime = time,
                        Value = val,
                        CityOfRegistration = city,
                        GoodItem = good
                    });
                }
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public List<PriceData> GetPricesData(DateTime since, DateTime till, List<string> citiesOfPriceRegistration = null)
    {
        using (SqlConnection connection = _connectionFactory.Create())
        {
            try
            {
                string sql = BuildSqlCommandText(citiesOfPriceRegistration);

                SqlCommand command = new SqlCommand(sql, connection);
                FillSqlParameters(since, till, citiesOfPriceRegistration, command);
                
                command.Connection.Open();
                var results = GetResultsByCitiesAndDateTimePeriod(command);
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    private List<PriceData> GetResultsByCitiesAndDateTimePeriod(SqlCommand command)
    {
        SqlDataReader reader = command.ExecuteReader();
        List<PriceData> results = new();
        while (reader.Read())
        {
            DateTime time = (DateTime)reader["registered_time"];
            string city = (string)reader["city_of_registration"];
            decimal val = (decimal)reader["value"];
            Good good = (Good)(int)reader["good_id"];
            results.Add(new PriceData
            {
                RegisteredTime = time,
                Value = val,
                CityOfRegistration = city,
                GoodItem = good
            });
        }

        return results;
    }

    private static string BuildSqlCommandText(List<string> citiesOfPriceRegistration)
    {
        string sql = "SELECT * FROM [statistics].prices WHERE registered_time >= @since AND registered_time < @till";
        if (citiesOfPriceRegistration != null)
        {
            sql += " AND city_of_registration IN (";
            for (int i = 0; i < citiesOfPriceRegistration.Count; i++)
            {
                if (i > 0)
                    sql += ", ";
                sql += "@city" + i;
            }

            sql += ")";
        }

        return sql;
    }

    private void FillSqlParameters(DateTime since, DateTime till, List<string> citiesOfPriceRegistration, SqlCommand command)
    {
        command.Parameters.AddWithValue("@since", since);
        command.Parameters.AddWithValue("@till", till);
        for (int i = 0; i < citiesOfPriceRegistration.Count; i++)
        {
            command.Parameters.AddWithValue("@city" + i, citiesOfPriceRegistration[i]);
        }
    }

    public List<PriceData> GetPricesData(List<Good> goods, Store store)
    {
        using (SqlConnection connection = _connectionFactory.Create())
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [statistics].[prices] WHERE [store_name] = @storeName", connection);
                command.Parameters.AddWithValue("@city", store.Name);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<PriceData> results = new();
                while (reader.Read())
                {
                    DateTime time = (DateTime)reader["registered_time"];
                    string city = (string)reader["city_of_registration"];
                    // string storeName = (string)reader["store_name"];
                    decimal val = (decimal)reader["value"];
                    Good good = (Good)(int)reader["good_id"];
                    results.Add(new PriceData
                    {
                        RegisteredTime = time,
                        Value = val,
                        CityOfRegistration = city,
                        // Market = store,
                        GoodItem = good
                    });
                }
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}