using BlogApi.Dtos.CategoryDtos;
using BlogApi.Repository.CategoryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceRepository _categoryServiceRepository;

        public CategoryController(ICategoryServiceRepository categoryServiceRepository)
        {
            _categoryServiceRepository = categoryServiceRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryServiceRepository.CreateCategoryAsync(createCategoryDto);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest("Kategori oluşturulamadı.Aynı Kategori tekrardan oluşturulamaz.");

        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryServiceRepository.GetAllCategoryAsync();
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _categoryServiceRepository.GetByIdCategoryAsync(id);
            if (result.CategoryName == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
            {
            var category = await _categoryServiceRepository.GetByIdCategoryAsync(updateCategoryDto.CategoryId);
            if (category.CategoryName == null)
            {
                return NotFound("Kategori Bulunamadı");
            }
            var result = await _categoryServiceRepository.UpdateCategoryAsync(updateCategoryDto);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetCategoryWithPost")]
        public async Task<IActionResult> GetCategoryWithPost(int id)
        {
            var result =await  _categoryServiceRepository.GetByIdCategoryWithPost(id);
       if(result.CategoryName == null)
            {
                return NotFound("Kategori Bulunamadı");
            }
            return Ok(result);
        }
 



    }
}
