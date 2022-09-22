using System.ComponentModel.DataAnnotations.Schema;

namespace DataConrats.Model;

[Table("prices", Schema = "statistics")]
public class PriceData
{
    [Column("registered_time")]
    public DateTime RegisteredTime { get; set; }
    [Column("value")]
    public decimal Value { get; set; }
    [Column("city_of_registration")]
    public string CityOfRegistration { get; set; }
    // public Store Market { get; set; }
    [Column("good_id")]
    public Good GoodItem { get; set; }
}