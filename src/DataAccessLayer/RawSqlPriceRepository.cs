using System.Data.SqlClient;
using DataContracts.Infrastructure;
using DataConrats.Model;

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
                        Good = good
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
                SqlCommand command = new SqlCommand("SELECT * FROM [statistics].[prices] WHERE [city_of_registration] = @city", connection);
                command.Parameters.AddWithValue("@city", citiesOfPriceRegistration);
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
                        Good = good
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
                    string storeName = (string)reader["store_name"];
                    decimal val = (decimal)reader["value"];
                    Good good = (Good)(int)reader["good_id"];
                    results.Add(new PriceData
                    {
                        RegisteredTime = time,
                        Value = val,
                        CityOfRegistration = city,
                        Market = store,
                        Good = good
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