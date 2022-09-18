using DataConrats.Model;

namespace DataContracts.Infrastructure;

/// <summary>
/// An abstraction on database table with price data. (CRUD)
/// </summary>
public interface IPriceRepository
{
    void CreatePriceData(PriceData dto);
    List<PriceData> GetPricesData(string cityOfPriceRegistration);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="since"></param>
    /// <param name="till"></param>
    /// <param name="citiesOfPriceRegistration">if null then all known cities</param>
    /// <returns></returns>
    List<PriceData> GetPricesData(DateTime since, DateTime till, List<string> citiesOfPriceRegistration = null);
    // todo any overloads GetPrices reqired in business logic classes to select data from DB
    List<PriceData> GetPricesData(List<Good> goods, Store store);
}