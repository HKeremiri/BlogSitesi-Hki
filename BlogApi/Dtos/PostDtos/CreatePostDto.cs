using BlogApi.Models;

namespace BlogApi.Dtos.PostDtos
{
    public class CreatePostDto
    {
       public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string? ImageUrl { get; set; }    
        public int CategoryId { get; set; }
        public List<int>? TagId{ get; set; }
    }
}
