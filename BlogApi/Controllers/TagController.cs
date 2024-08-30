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

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagDto createTagDto)
        {
          var result=  await  _tagServiceRepository.CreateTagAsync(createTagDto);
            return Ok();
        }

        
    }
}
