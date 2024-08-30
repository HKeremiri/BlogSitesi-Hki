using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Home
{
    public class _HomeLastBlogsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
