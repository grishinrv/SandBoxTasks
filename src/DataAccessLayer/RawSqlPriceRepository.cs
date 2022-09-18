using DataConrats.Infrastucture;
using DataConrats.Model;

namespace DataAccessLayer;

public class RawSqlPriceRepository : IPriceRepository
{
    public void CreatePriceData(PriceData dto)
    {
        throw new NotImplementedException();
    }

    public List<PriceData> GetPrices(string cityOfPriceRegistration)
    {
        throw new NotImplementedException();
    }

    public List<PriceData> GetPrices(DateTime since, DateTime till, List<string> citiesOfPriceRegistration = null)
    {
        throw new NotImplementedException();
    }

    public List<PriceData> GetPrices(List<Good> goods, Store store)
    {
        throw new NotImplementedException();
    }
}