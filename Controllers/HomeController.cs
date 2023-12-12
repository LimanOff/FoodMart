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

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context);
        }

        [HttpPost]
        public IActionResult Index(string productName)
        {
            var product = _context.Products.First(x => x.Name == productName);

            Cart cart = new Cart()
            {
                Product = product,
                UserId = Program.CurrentUser.Id
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCartINDEX(string productName)
        {
            var product = _context.Carts.First(x => x.Product.Name == productName);

            _context.Carts.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCartCART(string productName)
        {
            var product = _context.Carts.First(x => x.Product.Name == productName);

            _context.Carts.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }

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
            return View(_context); 
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Program.CurrentUser = null;
            return RedirectToAction("Registration");
        }
    }
}
