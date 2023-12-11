using FoodMart.Models.Infrastucture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodMart.Controllers
{
    public class HomeController : Controller
    {
        private readonly MainContext _context;
        public HomeController(MainContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public IActionResult Registration(string login, string password)
        {
            if (login != null && password != null)
            {
                User u = new() { Login = login, Password = password };

                if (_context.Users.FirstOrDefault(u => u.Login == login && u.Password == password) == null)
                {
                    _context.Users.Add(u);
                    _context.SaveChanges();

                    Program.CurrentUser = u;

                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Authorization() => View();

        [HttpPost]
        public IActionResult Authorization(string login, string password)
        {
            if (login != null && password != null)
            {
                User u = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                if (u != null)
                {
                    Program.CurrentUser = u;
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Cart()
        {
            ViewBag.CartPage = true;
            return View(); 
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Program.CurrentUser = null;
            return RedirectToAction("Registration");
        }
    }
}
