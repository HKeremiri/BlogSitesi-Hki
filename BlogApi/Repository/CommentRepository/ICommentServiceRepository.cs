using BlogApi.Dtos.CommentDto;

namespace BlogApi.Repository.CommentRepository
{
    public interface ICommentServiceRepository
    {
        Task<bool> CreateCommentAsync(CreateCommentDto createCategoryDto);

        Task<GetByIdCommentDto> GetByIdCommentAsync(int id);
        Task<List<GetAllCommentDto>> GetAllCommentAsync();

        Task<bool> UpdateCommentAsync(UpdateCommentDto updateCommentDto);


        Task<bool> DeleteCommentAsync(int id);
    }
}
