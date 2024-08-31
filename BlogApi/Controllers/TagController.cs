using BlogApi.Dtos.CategoryDtos;
using BlogApi.Dtos.TagDtos;
using BlogApi.Repository.TagRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagServiceRepository _tagServiceRepository;
        public TagController(ITagServiceRepository tagServiceRepository)
        {
            _tagServiceRepository = tagServiceRepository;
        }

     
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagDto createTagDto)
        {
          var result=  await  _tagServiceRepository.CreateTagAsync(createTagDto);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest("Tag oluşturulamadı.Aynı Tag tekrardan oluşturulamaz.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _tagServiceRepository.GetAllTagAsync();
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var result = await _tagServiceRepository.GetByIdTagAsync(id);
            if (result.TagName == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var result = await _tagServiceRepository.DeleteTagAsync(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagDto updateTagDto)
        {
            var tag = await _tagServiceRepository.GetByIdTagAsync(updateTagDto.TagId);
            if (tag.TagName == null)
            {
                return NotFound("Tag Bulunamadı");
            }
            var result = await _tagServiceRepository.UpdateTagAsync(updateTagDto);
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetTagWithPost/{id}")]
        public async Task<IActionResult> GetCategoryWithPost(int id)
        {
            var result = await _tagServiceRepository.GetByIdTagAsync(id);
            if (result.TagName == null)
            {
                return NotFound("Tag Bulunamadı");
            }
            return Ok(result);
        }

    }
}
