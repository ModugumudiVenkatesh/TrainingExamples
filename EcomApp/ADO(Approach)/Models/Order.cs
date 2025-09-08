using System;
using System.Collections.Generic;

namespace Models
{



    public partial class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string ShippingAddress { get; set; } = null;

        public virtual Customer Customer { get; set; } = null;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
