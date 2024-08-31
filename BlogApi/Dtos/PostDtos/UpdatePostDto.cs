using BlogApi.Models;

namespace BlogApi.Dtos.PostDtos
{
    public class UpdatePostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId  { get; set; }
        public string? ImageUrl { get; set; } 


        public string CategoryName { get; set; }
        public List<int> TagId { get; set; }
    }
}
