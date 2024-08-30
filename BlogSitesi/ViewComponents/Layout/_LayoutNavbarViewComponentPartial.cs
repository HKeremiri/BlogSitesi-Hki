using Microsoft.AspNetCore.Mvc;


namespace BlogSitesi.ViewComponents.Layout
{
    public class _LayoutNavbarViewComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
