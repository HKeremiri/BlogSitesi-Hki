namespace BlogApi.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public List<Post> Posts { get; set; }  
    }
}
