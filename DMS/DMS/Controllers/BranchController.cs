using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class BranchController : Controller
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
