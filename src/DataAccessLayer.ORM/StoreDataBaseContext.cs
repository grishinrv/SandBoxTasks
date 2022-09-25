using DataConrats.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.ORM
{
    internal class StoreDataBaseContext : DbContext
    {
        /// <summary>
        /// This prop is an avatar of table "stores" in database
        /// </summary>
        public DbSet<Store> Stores { get; set; }
    }
}
