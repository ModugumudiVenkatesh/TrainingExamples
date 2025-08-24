using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }


        public DateTime OrderDate { get; set; } = DateTime.UtcNow;


        public decimal TotalPrice { get; set; }


        [Required, StringLength(500)]
        public string ShippingAddress { get; set; } = string.Empty;


        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
