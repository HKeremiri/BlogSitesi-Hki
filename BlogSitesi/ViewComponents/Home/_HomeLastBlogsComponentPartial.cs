using BlogSitesi.Dtos.PostDtos;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Home
{
    public class _HomeLastBlogsComponentPartial : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;
        public _HomeLastBlogsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = client.GetAsync("https://localhost:7113/api/Post").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync().Result;
                var posts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetAllPostDto>>(jsonData);
               
                return View(posts.TakeLast(3).ToList());
            }
            return View();
        }
    }
}
