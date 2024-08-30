using BlogApi.Dtos.RoleDtos;
using BlogApi.Dtos.UserDtos;
using BlogApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Repository.UserRepository;
using Azure.Core;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> ResultAsync(RegisterDto register)
        {
            var result = await _userService.RegisterAsync(register);
            return Ok(result); ;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);

            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetByIdUser(id);
            if (result.Id == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result == true)
            {
                return Ok("Kullanıcı Silindi");
            }
            else
            {
                return BadRequest("Bir hata oluştu ");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            var result = await _userService.UpdateUserAsync(user);
            if (result.IsSuccessful==true)
            {
                return Ok("Kullanıcı Güncellendi");
            }
            else if (result.IsSuccessful==false && result.Errors==null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
            return BadRequest(result.Errors);
        }
        




    }
}
