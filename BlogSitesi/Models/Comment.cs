namespace BlogSitesi.Models
{
    public class Comment
    {
        public int CommentId  { get; set; }

        public string Content { get; set; }

        public AppUser User { get; set; }

        public Post Post { get; set; }

        public DateTime CreateTime { get; set; } 

        public DateTime? UpdateTime { get; set; }
    }
}
