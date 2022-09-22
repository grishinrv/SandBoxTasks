using DataConrats.Model;
using DataContracts.Infrastructure;

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
        throw new NotImplementedException(); // todo
    }

    public List<PriceData> GetPricesData(List<Good> goods, Store store)
    {
        throw new NotImplementedException(); //todo
    }
}