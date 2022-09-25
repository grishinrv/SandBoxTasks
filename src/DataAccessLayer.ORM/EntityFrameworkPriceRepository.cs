using DataConrats.Model;
using DataContracts.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.ORM;

public class EntityFrameworkPriceRepository : IPriceRepository
{
    private readonly PricesDataBaseContext _dbContext;
    
    public EntityFrameworkPriceRepository(PricesDataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void CreatePriceData(PriceData dto)
    {
        throw new NotImplementedException(); // пока не нужно
    }

    public List<PriceData> GetPricesData(string cityOfPriceRegistration)
    {
        return _dbContext.Prices.Where(x => x.CityOfRegistration == cityOfPriceRegistration).ToList();
    }

    public List<PriceData> GetPricesData(DateTime since, DateTime till, List<string> citiesOfPriceRegistration = null)
    {
        var result = new List<PriceData>();

        foreach (var city in citiesOfPriceRegistration)
        {
            result.AddRange(_dbContext.Prices.Where(x => x.RegisteredTime >= since && x.RegisteredTime <= till).Where(x => x.CityOfRegistration == city));
        }

        return result;
    }

    public List<PriceData> GetPricesData(List<Good> goods, Store store)
    {
        var result = new List<PriceData>();

        

        return result;
    }
}