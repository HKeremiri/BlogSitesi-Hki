using BlogSitesi.Models;

namespace BlogSitesi.Dtos.PostDtos
{
    public class GetPostWithCommentsAndTags
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AppUser Author { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateTime { get; set; }
        public List<Comment>? Comments { get; set; }               
        public Category Category { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
