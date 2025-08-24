using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Ecom.Exceptions;
using Repos.IEcom;

namespace Repos.Ecom
{
    public class OrderProcessorRepositoryImpl : IOrderProcessorRepository
    {
        private readonly EcomDbContext _db;
        public OrderProcessorRepositoryImpl(EcomDbContext db) => _db = db;

        // -------------------- Product --------------------
        public bool CreateProduct(Product product)
        {
            _db.Products.Add(product);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteProduct(int productId)
        {
            var p = _db.Products.Find(productId) ?? throw new ProductNotFoundException(productId);
            _db.Products.Remove(p);
            return _db.SaveChanges() > 0;
        }

        // -------------------- Customer --------------------
        public bool CreateCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteCustomer(int customerId)
        {
            var c = _db.Customers
                .Include(x => x.CartItems)
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.CustomerId == customerId)
                ?? throw new CustomerNotFoundException(customerId);

            _db.Cart.RemoveRange(c.CartItems);
            _db.Customers.Remove(c);
            return _db.SaveChanges() > 0;
        }

        // -------------------- Cart --------------------
        public bool AddToCart(int customerId, int productId, int quantity)
        {
            var c = _db.Customers.Find(customerId) ?? throw new CustomerNotFoundException(customerId);
            var p = _db.Products.Find(productId) ?? throw new ProductNotFoundException(productId);

            if (p.StockQuantity < quantity)
                throw new InsufficientStockException(p.ProductId);

            var existing = _db.Cart.SingleOrDefault(x => x.CustomerId == c.CustomerId && x.ProductId == p.ProductId);
            if (existing == null)
            {
                _db.Cart.Add(new CartItem { CustomerId = c.CustomerId, ProductId = p.ProductId, Quantity = quantity });
            }
            else
            {
                existing.Quantity += quantity;
                _db.Cart.Update(existing);
            }

            return _db.SaveChanges() > 0;
        }

        public bool RemoveFromCart(int customerId, int productId)
        {
            var item = _db.Cart.SingleOrDefault(x => x.CustomerId == customerId && x.ProductId == productId);
            if (item == null) return false;

            _db.Cart.Remove(item);
            return _db.SaveChanges() > 0;
        }

        public IEnumerable<CartItem> GetAllFromCart(int customerId)
        {
            var c = _db.Customers.Find(customerId) ?? throw new CustomerNotFoundException(customerId);

            return _db.Cart
                .Include(ci => ci.Product)
                .Where(ci => ci.CustomerId == c.CustomerId)
                .AsNoTracking()
                .ToList();
        }

        // -------------------- Orders --------------------
        public bool PlaceOrder(int customerId, IEnumerable<(int productId, int quantity)> items, string shippingAddress)
        {
            var c = _db.Customers.Find(customerId) ?? throw new CustomerNotFoundException(customerId);

            if (string.IsNullOrWhiteSpace(shippingAddress))
                throw new ArgumentException("Shipping address is required");

            var orderItems = new List<OrderItem>();
            decimal total = 0m;

            foreach (var (pid, qty) in items)
            {
                var p = _db.Products.Find(pid) ?? throw new ProductNotFoundException(pid);
                if (qty <= 0) throw new ArgumentException("Quantity must be greater than 0");
                if (p.StockQuantity < qty) throw new InvalidOperationException($"Insufficient stock for product {p.ProductId}");

                orderItems.Add(new OrderItem { ProductId = p.ProductId, Quantity = qty });
                total += p.Price * qty;
                p.StockQuantity -= qty;
            }

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                ShippingAddress = shippingAddress,
                TotalPrice = total,
                Items = orderItems
            };

            _db.Orders.Add(order);

            // Clear cart for the customer
            var cartItems = _db.Cart.Where(ci => ci.CustomerId == customerId);
            _db.Cart.RemoveRange(cartItems);

            return _db.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetOrdersByCustomer(int customerId)
        {
            var c = _db.Customers.Find(customerId) ?? throw new CustomerNotFoundException(customerId);

            return _db.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == c.CustomerId)
                .OrderByDescending(o => o.OrderDate)
                .AsNoTracking()
                .ToList();
        }
    }
}
