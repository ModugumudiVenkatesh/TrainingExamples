using Microsoft.AspNetCore.Mvc;
using Models;
using Repos.IEcom;

namespace EcomApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IOrderProcessorRepository _repo;
        public CustomerController(IOrderProcessorRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult Register() => View(new Customer());

        [HttpPost]
        public IActionResult Register(Customer model)
        {
            if (!ModelState.IsValid) return View(model);
            _repo.CreateCustomer(model);
            TempData["msg"] = $"Customer {model.Name} registered.";
            return RedirectToAction("Register");
        }
    }
}
