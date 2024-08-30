

using BlogApi.Dtos.CategoryDtos;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository.CategoryRepository
{
    public class CategoryServiceRepository : ICategoryServiceRepository
    {
        private readonly Context _context;

        public CategoryServiceRepository(Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == createCategoryDto.CategoryName);
            if (result != null)
            {
                return false;
            }
            await _context.Categories.AddAsync(new Category
            {
                CategoryName = createCategoryDto.CategoryName
            });
            var success = await _context.SaveChangesAsync();
            if (success > 0)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
            if (result != null)
            {
                _context.Categories.Remove(result);

                return true;
            }
            return false;


        }

        public async Task<List<GetAllCategoryDto>> GetAllCategoryAsync()
        {
            var result = await _context.Categories.ToListAsync();
            var categoryDtos = new List<GetAllCategoryDto>();

            if (result != null)
            {
                foreach (var category in result)
                {
                    categoryDtos.Add(new GetAllCategoryDto
                    {
                        CategoryName = category.CategoryName,
                        CategoryId = category.CategoryId
                    });
                }
            }

            return categoryDtos;
        }
        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (result != null)
            {
                return new GetByIdCategoryDto { CategoryId = result.CategoryId, CategoryName = result.CategoryName };

            }

            return new GetByIdCategoryDto();
        }

        public async Task<GetCategoryWithPostDto> GetByIdCategoryWithPost(int id)
        {
            var result = await _context.Categories.Include(x => x.Posts).FirstOrDefaultAsync(x => x.CategoryId == id);
            if (result != null)
            {
                return await Task.FromResult(new GetCategoryWithPostDto { CategoryId = result.CategoryId, CategoryName = result.CategoryName, Posts = result.Posts });
            }
            return new GetCategoryWithPostDto();
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == updatecategoryDto.CategoryName);
            if (category != null)
            {
                return false;
            }
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c=> c.CategoryId == updatecategoryDto.CategoryId);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.CategoryName = updatecategoryDto.CategoryName;
            var success = await _context.SaveChangesAsync();
            return success > 0;
        }
    }
}
