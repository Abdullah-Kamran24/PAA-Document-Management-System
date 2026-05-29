using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "Document" && password == "paa1234")
            {
                return RedirectToAction("Index", "Home"); 
            }

            ViewBag.Message = "Invalid credentials!";
            return View();
        }
    }
}
