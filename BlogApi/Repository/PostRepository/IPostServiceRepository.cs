using BlogApi.Dtos.PostDtos;

namespace BlogApi.Repository.PostRepository
{
    public interface IPostServiceRepository
    {
        Task<CreatePostDto> CreatePostAsync(CreatePostDto createPostDto);

        Task<GetByIdPostDto> GetByIdPost(int id);

        Task<List<GetAllPostDto>> GetAllPostsAsync();

        Task<bool> UpdatePostAsync(UpdatePostDto updatePostDto);
 

        Task<bool> DeletePostAsync(int id);

      
    }
}
