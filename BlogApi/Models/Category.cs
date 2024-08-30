using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models
{
    public class Category
    {
        public int CategoryId  { get; set; }

        public string CategoryName { get; set; }

        public List<Post> Posts { get; set; }

    }
}
