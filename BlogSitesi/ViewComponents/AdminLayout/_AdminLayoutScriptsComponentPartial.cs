using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
       
    }
}
