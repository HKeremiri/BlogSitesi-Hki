using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Blogs() { return View(); }

        public IActionResult Categories() { return View(); }

        public IActionResult Users() { return View();}

        public IActionResult Tags() { return View();}

        public IActionResult Comments() { return View();}

        public IActionResult Roles() { return View(); }
    }
}
