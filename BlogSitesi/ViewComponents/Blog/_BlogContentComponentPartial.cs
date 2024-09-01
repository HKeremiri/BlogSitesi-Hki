using BlogSitesi.Dtos.PostDtos;
using Microsoft.AspNetCore.Mvc;

namespace BlogSitesi.ViewComponents.Blog
{
    public class _BlogContentComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogContentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke(int Postid)
        {
            Postid = 2;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = client.GetAsync("https://localhost:7113/api/Post/{Postid}").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync().Result;
                var post = Newtonsoft.Json.JsonConvert.DeserializeObject<GetByIdPostDto>(jsonData);
               

                return View(post);
            }
            return View();
           
        }
       
    }
}
