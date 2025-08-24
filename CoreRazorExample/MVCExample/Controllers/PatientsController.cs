using CoreRazorExample.Data;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Data;
using MVCExample.Models;
namespace MVCExample.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Patient> plist = _context.patients.ToList();
            return View(plist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Allergies)
        {
            Patient p = new Patient();
            p.Allergies = Allergies;
            p.Name = Name;
            _context.patients.Add(p);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int Id)
        {
            if (Id == null)
                return NotFound();
            Patient p = _context.patients.Find(Id);
                return View(p);
        }
        [HttpPost]
        public IActionResult Edit(Patient p)
        {
            _context.patients.Update(p);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        //public IActionResult Delete(int Id)
        //{
        //    _context.patients.Remove(_context.patients.Find(Id));
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public IActionResult Delete(int Id)
        {
            return View(_context.patients.Find(Id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteMethod(int Id)
        {
            _context.patients.Remove(_context.patients.Find(Id));
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        

    }
}
