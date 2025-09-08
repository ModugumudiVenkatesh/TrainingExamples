using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repos.IEcom
{
    public interface IOrderProcessorRepository
    {
        bool CreateProduct(Product product);
        bool CreateCustomer(Customer customer);
        bool DeleteProduct(int productId);
        bool DeleteCustomer(int customerId);


        bool AddToCart(int customerId, int productId, int quantity);
        bool RemoveFromCart(int customerId, int productId);
        IEnumerable<CartItem> GetAllFromCart(int customerId);


        bool PlaceOrder(int customerId, IEnumerable<(int productId, int quantity)> items, string shippingAddress);
        IEnumerable<Order> GetOrdersByCustomer(int customerId);
    }
}
