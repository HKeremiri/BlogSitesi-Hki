using System.Reflection.Metadata.Ecma335;

namespace BlogApi.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } 
        public string Content { get; set; }
        public AppUser Author { get; set; } 
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdateTime { get; set; }


        public Category Category { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
