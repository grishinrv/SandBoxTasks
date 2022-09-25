using System.ComponentModel.DataAnnotations.Schema;

namespace DataConrats.Model
{
    [Table("store", Schema = "statistics")]
    public class Store
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("adress")]
        public string Adress { get; set; }
    }
}
