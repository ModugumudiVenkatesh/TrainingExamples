using Microsoft.AspNetCore.Mvc;
using Models;
using Repos.IEcom;

namespace EcomApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IOrderProcessorRepository _repo;
        public ProductController(IOrderProcessorRepository repo) => _repo = repo;

        public IActionResult Index([FromServices] Repos.EcomDbContext db)
        {
            var items = db.Products.ToList();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create() => View(new Product());

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (!ModelState.IsValid) return View(model);
            _repo.CreateProduct(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repo.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
