using BlogSitesi.Dtos.CommentDtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BlogSitesi.Controllers
{

	public class CommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public CommentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
		{
			if (ModelState.IsValid)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(createCommentDto);
				StringContent stringContent=new StringContent(jsonData, Encoding.UTF8, "application/json");
				var response = await client.PostAsJsonAsync("https://localhost:7113/api/Comment", stringContent);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadFromJsonAsync<CreateCommentDto>();
					return RedirectToAction("Index","Blog");
				}
			}
			
			return RedirectToAction("Index","Blog");
		}
	}
}
