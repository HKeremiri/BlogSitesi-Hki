using BlogApi.Dtos.CategoryDtos;

namespace BlogApi.Repository.CategoryRepository
{
    public interface ICategoryServiceRepository
    {
        Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);
        Task<GetCategoryWithPostDto> GetByIdCategoryWithPost(int id);

        Task<List<GetAllCategoryDto>> GetAllCategoryAsync();

        Task<bool> UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto);


        Task<bool> DeleteCategoryAsync(int id);
    }
}
