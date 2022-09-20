namespace DataConrats.Model;

public class PriceData
{
    public DateTime RegisteredTime { get; set; }
    public decimal Value { get; set; }
    public string CityOfRegistration { get; set; }
    public Store Market { get; set; }
    public Good Good { get; set; }
}