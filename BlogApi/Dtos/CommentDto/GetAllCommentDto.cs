namespace BlogApi.Dtos.CommentDto
{
    public class GetAllCommentDto
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public int PostId { get; set; }
        public DateTime? UpdateTime { get; set; }

        public DateTime CreateTime { get; set; } 
    }
}
