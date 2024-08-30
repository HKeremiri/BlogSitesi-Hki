using BlogApi.Models;

namespace BlogApi.Dtos.TagDtos
{
    public class GetTagWithPostDto
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public List<Post> Posts { get; set; }
    }
}
