using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }


        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;


        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 9999999999.99)]
        public decimal Price { get; set; }


        [StringLength(1000)]
        public string? Description { get; set; }


        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
