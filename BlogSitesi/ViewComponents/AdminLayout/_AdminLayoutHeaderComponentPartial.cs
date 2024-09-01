using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
