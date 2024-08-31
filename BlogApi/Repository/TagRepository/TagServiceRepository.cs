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

        public async Task<bool> DeleteTagAsync(int id)
        {
            var result = await _context.Tags.FirstOrDefaultAsync(p => p.TagId == id);
            if (result != null)
            {
                _context.Tags.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<GetAllTagDto>> GetAllTagAsync()
        {
            var result = await _context.Tags.ToListAsync();
            var getAllTagDtos = new List<GetAllTagDto>();

            if (result != null)
            {
                foreach (var category in result)
                {
                    getAllTagDtos.Add(new GetAllTagDto
                    {
                        TagName = category.TagName,
                        TagId = category.TagId
                    });
                }
            }

            return getAllTagDtos;
        }

        public async Task<GetByIdTagDto> GetByIdTagAsync(int id)
        {
            var result = await _context.Tags.FirstOrDefaultAsync(x => x.TagId == id);
            if (result != null)
            {
                return new GetByIdTagDto { TagId = result.TagId, TagName = result.TagName };

            }

            return new GetByIdTagDto();
        }

        public async Task<GetTagWithPostDto> GetByIdTagWithPostAsync(int id)
        {
            var result = await _context.Tags.Include(x => x.Posts).FirstOrDefaultAsync(x => x.TagId == id);
            if (result != null)
            {
                return await Task.FromResult(new GetTagWithPostDto { TagId = result.TagId, TagName = result.TagName, Posts = result.Posts });
            }
            return new GetTagWithPostDto();
        }

        public async Task<bool> UpdateTagAsync(UpdateTagDto updateTagDto)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(c => c.TagName == updateTagDto.TagName);
            if (tag != null)
            {
                return false;
            }
            var existingtag = await _context.Tags
                .FirstOrDefaultAsync(c => c.TagId == updateTagDto.TagId);
            if (existingtag == null)
            {
                return false;
            }

            existingtag.TagName = updateTagDto.TagName;
            var success = await _context.SaveChangesAsync();
            return success > 0;
        }
    }
}
