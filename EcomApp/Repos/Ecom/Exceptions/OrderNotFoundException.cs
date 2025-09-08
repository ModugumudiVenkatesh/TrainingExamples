using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Ecom.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(int id)
            : base($"Order with ID {id} not found.") { }
    }
}
