using BlogApi.Dtos.RoleDtos;
using BlogApi.Dtos.UserDtos;
using BlogApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Dtos.PostDtos;

namespace BlogApi.Repository.PostRepository
{
    public interface IPostServiceRepository
    {
        Task<CreatePostDto> CreatePostAsync(CreatePostDto createPostDto);

        Task<GetByIdPostDto> GetByIdPost(string id);

        Task<List<GetAllPostDto>> GetAllPostsAsync();

        Task<UpdatePostDto> UpdatePostAsync(UpdatePostDto updatePostDto);
 

        Task<bool> DeletePostAsync(string id);

      
    }
}
