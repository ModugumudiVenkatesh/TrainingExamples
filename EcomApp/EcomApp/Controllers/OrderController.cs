using Microsoft.AspNetCore.Mvc;
using Repos.Ecom.Exceptions;
using Repos.IEcom;

namespace EcomApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderProcessorRepository _repo;
        public OrderController(IOrderProcessorRepository repo) => _repo = repo;

        private int CurrentCustomerId => 1;

        public IActionResult History()
        {
            var orders = _repo.GetOrdersByCustomer(CurrentCustomerId);
            return View(orders);
        }

        [HttpPost]
        public IActionResult Place(string shippingAddress)
        {
            try
            {
                var cart = _repo.GetAllFromCart(CurrentCustomerId)
                                .Select(ci => (ci.ProductId, ci.Quantity));
                _repo.PlaceOrder(CurrentCustomerId, cart, shippingAddress);
                return RedirectToAction("History");
            }
            catch (InsufficientStockException ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }

    }
}
