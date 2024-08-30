using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Layout
{
    public class _LayoutFooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
