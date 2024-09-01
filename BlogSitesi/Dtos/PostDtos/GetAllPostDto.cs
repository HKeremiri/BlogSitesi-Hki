namespace BlogSitesi.Dtos.PostDtos
{
    public class GetAllPostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public List<int> TagId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateTime { get; set; }


        public string CategoryName { get; set; }
        public List<string>? TagName { get; set; }
    }
}
