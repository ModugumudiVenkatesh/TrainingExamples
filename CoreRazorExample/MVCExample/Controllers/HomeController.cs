using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MVCExample.Models;

namespace MVCExample.Controllers
{
    //[Authorize]  //when we have both authorize and authorize(role =admin) we get home as access denied for other user
    //[Authorize(Roles = "admin")] //and when we have only authorize(role =admim) we get new user access denied
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMongoDatabase _database;


        public HomeController(ILogger<HomeController> logger, IMongoDatabase database)
        {
            _logger = logger;
            _database = database;

        }


        //[Authorize(Roles = "admin")]
         

        public IActionResult Index()
        {
            var orgList = _database.GetCollection<Organization>("cart");
            return View();
        }




        [Authorize(Roles = "staff")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
