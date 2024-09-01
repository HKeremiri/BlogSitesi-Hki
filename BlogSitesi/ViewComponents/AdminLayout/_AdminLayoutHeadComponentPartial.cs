using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
       
    }
}
