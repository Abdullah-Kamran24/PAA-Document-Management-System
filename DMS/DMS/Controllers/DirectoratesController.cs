using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class DirectoratesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult create()
        {
            return View();
        }

        public IActionResult update()
        {
            return View();
        }
    }
}
