using BlogApi.Models;

namespace BlogApi.Dtos.CategoryDtos
{
    public class GetCategoryWithPostDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<Post> Posts { get; set; }
    }
}
