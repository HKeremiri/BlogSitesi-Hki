using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Home
{
    public class _HomeBlogoftheDayComponentPartial:ViewComponent
    {
       
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
