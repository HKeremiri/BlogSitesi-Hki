using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.AdminLayout
{
    public class _AdminLayoutSideBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
       
    }
}
