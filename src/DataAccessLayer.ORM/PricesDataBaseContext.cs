using DataConrats.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.ORM;

public class PricesDataBaseContext : DbContext
{
    /// <summary>
    /// This prop is an avatar of table "prices" in database
    /// </summary>
    public DbSet<PriceData> Prices { get; set; }
}