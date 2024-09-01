using BlogSitesi.Dtos.PostDtos;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Home
{
    public class _HomeBlogoftheDayComponentPartial : ViewComponent
    {

        private IHttpClientFactory _httpClientFactory;
        public _HomeBlogoftheDayComponentPartial(IHttpClientFactory httpClientFactory)
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
                Random random = new Random();

                return View(posts[random.Next(0, posts.Count())]);
            }
            return View();
        }
    }
}
