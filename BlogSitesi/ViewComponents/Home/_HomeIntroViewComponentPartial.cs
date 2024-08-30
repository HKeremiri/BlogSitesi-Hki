using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Home
{
    public class _HomeIntroViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
