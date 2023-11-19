using Microsoft.AspNetCore.Mvc;

namespace FoodMart.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public IActionResult Registration(string login, string password)
        {
            if(login != null && password != null)
            {
                string authData = $"Login: {login}   Password: {password}";
                return Content(authData);
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
                string authData = $"Login: {login}   Password: {password}";
                return Content(authData);
            }
            return View();
        }


        [HttpPost]
        public IActionResult LoadAuthForm()
        {
            return RedirectToAction("Authorization");
        }
        [HttpPost]
        public IActionResult LoadRegForm()
        {
            return RedirectToAction("Registration");
        }
    }
}
