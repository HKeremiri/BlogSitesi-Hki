using BlogApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required]
        
         public string CategoryName { get; set; }

      
    }
}
