using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }


        [Required]
        public int OrderId { get; set; }
        public Order? Order { get; set; }


        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }


        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
