using DataContracts.Infrastructure;

namespace WebApi.Domain;

public sealed class StatisticsManager
{
    private readonly IPriceRepository _repository;
    public StatisticsManager(IPriceRepository priceRepository)
    {
        _repository = priceRepository;
    }

    public void SomeUsefulMethod()
    {
        var prices = _repository.GetPricesData(DateTime.Now, DateTime.Today - TimeSpan.FromHours(48));
        //todo
    }
}