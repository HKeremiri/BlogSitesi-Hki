using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blog
{
	public class _BlogCommentComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
		
	}
}
