namespace BlogSitesi.Dtos.PostDtos
{
    public class GetByIdPostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string? ImageUrl { get; set; }
        public string CreatedAt { get; set; }

        public DateTime? UpdateTime { get; set; }


        public string CategoryName { get; set; }

        public List<string>? TagName { get; set; }
    }
}
