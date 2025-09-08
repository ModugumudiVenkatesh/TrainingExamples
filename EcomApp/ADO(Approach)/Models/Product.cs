using System;
using System.Collections.Generic;

namespace Models
{

    public partial class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null;

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
