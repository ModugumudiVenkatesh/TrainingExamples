using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //[ForeignKey("categ")]
        public double Price { get; set; }

        public int CategID { get; set; }
        public Category? Categ { get; set; }

    }
}
