using WebApi.Model;

namespace WebApi.Infrastucture;

/// <summary>
/// An abstraction on database table with price data. (CRUD)
/// </summary>
public interface IPriceRepository
{
    void CreatePriceData(PriceData dto);
    List<PriceData> GetPrices(string cityOfPriceRegistration);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="since"></param>
    /// <param name="till"></param>
    /// <param name="citiesOfPriceRegistration">if null then all known cities</param>
    /// <returns></returns>
    List<PriceData> GetPrices(DateTime since, DateTime till, List<string> citiesOfPriceRegistration = null);
    // todo любые другие перегрузки GetPrices необходимые в классах бизнес логики для выбора данных из бд
    // List<PriceData> GetPrices(List<Good> goods);
}