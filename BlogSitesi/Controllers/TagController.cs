using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
