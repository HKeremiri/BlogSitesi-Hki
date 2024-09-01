using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
