namespace BlogSitesi.Models
{
    public class Category
    {
        public int CategoryId  { get; set; }

        public string CategoryName { get; set; }

        public List<Post> Posts { get; set; }

    }
}
