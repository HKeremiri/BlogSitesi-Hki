using BlogApi.Models;

namespace BlogApi.Dtos.PostDtos
{
    public class CreatePostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } 

        public DateTime? UpdateTime { get; set; }


        public int CategoryId { get; set; }
        public int TagId{ get; set; }
    }
}
