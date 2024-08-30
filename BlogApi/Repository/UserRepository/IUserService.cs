using BlogApi.Dtos;
using BlogApi.Dtos.RoleDtos;
using BlogApi.Dtos.UserDtos;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BlogApi.Repository.UserRepository
{
    public interface IUserService
    {
        Task<IActionResult> RegisterAsync(RegisterDto model);

        Task<GetByIdUserDto> GetByIdUser(string id);

        Task<List<GetUsersDto>> GetAllUsers();

        Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserDto model);
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);

        Task<bool> DeleteUserAsync(string id);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
