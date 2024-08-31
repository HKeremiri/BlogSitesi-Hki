using BlogApi.Dtos.CommentDto;
using BlogApi.Repository.CommentRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServiceRepository _commentServiceRepository;

        public CommentController(ICommentServiceRepository commentServiceRepository)
        {
            _commentServiceRepository = commentServiceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var result= await _commentServiceRepository.CreateCommentAsync(createCommentDto);
            if(result is false)
            {
                return BadRequest("Yorum oluşturulamadı");
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var result= await _commentServiceRepository.GetAllCommentAsync();
            if(result is null)
            {
                return NotFound("Yorum bulunamadı");
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var result= await _commentServiceRepository.GetByIdCommentAsync(id);
            if(result.Content== "Yorum Bulunamadı" )
            {
                return NotFound("Yorum bulunamadı");
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result= await _commentServiceRepository.DeleteCommentAsync(id);
            if(result is false)
            {
                return BadRequest("Yorum silinemedi");
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var result= await _commentServiceRepository.UpdateCommentAsync(updateCommentDto);
            if(result is false)
            {
                return BadRequest("Yorum güncellenemedi");
            }
            return Ok(result);
        }
      

     
}
}
