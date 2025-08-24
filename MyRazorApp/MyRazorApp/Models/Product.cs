using System.ComponentModel.DataAnnotations.Schema;

namespace MyRazorApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //[ForeignKey("categ")]
        public int CatergID { get; set; }
        public Category? Categ {  get; set; }

    }
}
