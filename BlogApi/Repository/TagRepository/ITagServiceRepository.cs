using BlogApi.Dtos.TagDtos;

namespace BlogApi.Repository.TagRepository
{
    public interface ITagServiceRepository
    {
        Task<bool> CreateTagAsync(CreateTagDto createTagDto);

        Task<GetByIdTagDto> GetByIdTagAsync(int id);
        Task<GetTagWithPostDto> GetByIdTagWithPostAsync(int id);

        Task<List<GetAllTagDto>> GetAllTagAsync();

        Task<bool> UpdateTagAsync(UpdateTagDto updateTagDto);


        Task<bool> DeleteTagAsync(int id);
    }
}
