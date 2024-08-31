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
            if(post.Content=="Tag bulunamadı")
            {
                return NotFound("Tag Bulunamadı");
            }
            if(post.Title == null )
            {
                return BadRequest("Post Oluşturulamadı");
            }
            return Ok(post);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            var exist =await _postServiceRepository.GetByIdPost(id);
            if(exist.PostId == 0)
            {
                return NotFound("Post Bulunamadı");
            }
            var post = await _postServiceRepository.DeletePostAsync(id);
            if (post ==false)
            {
                return BadRequest("Post Silinemedi");
            }
            return Ok(post);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var posts = await _postServiceRepository.GetAllPostsAsync();
            if(posts.Count==0 )
            {
                return NotFound("Post Bulunamadı");
            }
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPost(int id)
        {
            var post = await _postServiceRepository.GetByIdPost(id);
            if(post.PostId == 0)
            {
                return NotFound("Post Bulunamadı");
            }
            return Ok(post);
        }
        [HttpPut]
              public async Task<IActionResult> UpdatePost(UpdatePostDto updatePostDto)
        {
            var exist = await _postServiceRepository.GetByIdPost(updatePostDto.PostId);
            if (exist.PostId == 0)
            {
                return NotFound("Post Bulunamadı");
            }
            var post = await _postServiceRepository.UpdatePostAsync(updatePostDto);
            if (post is false)
            {
                return BadRequest("Post Güncellenemedi");
            }
            return Ok(post);
        }
    
      

    }
}
