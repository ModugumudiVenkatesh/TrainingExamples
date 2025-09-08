using Microsoft.AspNetCore.Mvc;
using Repos.IEcom;

namespace EcomApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrderProcessorRepository _repo;
        public CartController(IOrderProcessorRepository repo) => _repo = repo;

        // For demo: fixed customerId (1). Replace later with logged-in user.
        private int CurrentCustomerId => 1;

        public IActionResult Index()
        {
            var items = _repo.GetAllFromCart(CurrentCustomerId);
            return View(items);
        }

        [HttpPost]
        public IActionResult Add(int productId, int quantity = 1)
        {
            _repo.AddToCart(CurrentCustomerId, productId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            _repo.RemoveFromCart(CurrentCustomerId, productId);
            return RedirectToAction("Index");
        }
    }
}
