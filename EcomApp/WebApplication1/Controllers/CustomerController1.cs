using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class CustomerController1 : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
