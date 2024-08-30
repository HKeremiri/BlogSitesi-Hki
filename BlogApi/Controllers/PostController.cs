using BlogApi.Dtos.PostDtos;
using BlogApi.Repository.PostRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServiceRepository _postServiceRepository;

        public PostController(IPostServiceRepository postServiceRepository)
        {
            _postServiceRepository = postServiceRepository;
        }              

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDto createPostDto)
        {         

        var post=   await _postServiceRepository.CreatePostAsync(createPostDto);
            if(post == null )
            {
                return BadRequest("Post not created");
            }
            return Ok(post);
        }      
    }
}
