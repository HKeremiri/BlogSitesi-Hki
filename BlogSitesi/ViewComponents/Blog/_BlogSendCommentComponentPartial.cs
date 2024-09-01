using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blog
{
	public class _BlogSendCommentComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	
		
	}
}
