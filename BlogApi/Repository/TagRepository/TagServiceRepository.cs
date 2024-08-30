using BlogApi.Dtos.CategoryDtos;
using BlogApi.Dtos.TagDtos;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository.TagRepository
{
    public class TagServiceRepository : ITagServiceRepository
    {
        private readonly Context _context;

        public TagServiceRepository(Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateTagAsync(CreateTagDto createTagDto)
        {

            var result = await _context.Tags.FirstOrDefaultAsync(x => x.TagName == createTagDto.TagName);
            if (result != null)
            {
                return false;
            }
            await _context.Tags.AddAsync(new Tag { TagName = createTagDto.TagName });
            
    
            var success = await _context.SaveChangesAsync();
            if (success > 0)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllTagDto>> GetAllTagAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdTagDto> GetByIdTagAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetTagWithPostDto> GetByIdTagWithPostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTagAsync(UpdateTagDto updateTagDto)
        {
            throw new NotImplementedException();
        }
    }
}
