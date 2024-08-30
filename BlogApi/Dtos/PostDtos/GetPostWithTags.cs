using BlogApi.Models;

namespace BlogApi.Dtos.PostDtos
{
    public class GetPostWithTags
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AppUser Author { get; set; }
        public string? ImageUrl { get; set; }
     
        public List<Tag> Tags { get; set; }
    }
}
