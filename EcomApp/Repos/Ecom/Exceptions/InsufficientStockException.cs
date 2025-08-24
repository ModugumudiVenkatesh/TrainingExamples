using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Ecom.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(int productId)
            : base($"Not enough stock available for product {productId}") { }
    }
}
