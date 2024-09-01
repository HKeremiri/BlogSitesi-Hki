using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(int PostId)
        {
            return View(PostId);
        }
        public IActionResult BlogList()
        {
            return View();
        }

    }
}
