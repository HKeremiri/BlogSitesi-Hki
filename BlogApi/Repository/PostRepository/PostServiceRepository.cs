using BlogApi.Dtos.CategoryDtos;
using BlogApi.Dtos.CommentDto;
using BlogApi.Dtos.PostDtos;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogApi.Repository.PostRepository
{
    public class PostServiceRepository : IPostServiceRepository
    {
        private readonly Context _context;
        public PostServiceRepository(Context context)
        {
            _context = context;
        }
        public async Task<CreatePostDto> CreatePostAsync(CreatePostDto createPostDto)
        {
            var user = await _context.Users.FindAsync(createPostDto.UserId);
            var category = await _context.Categories.FindAsync(createPostDto.CategoryId);
            List<Tag> tags = new List<Tag>();
            if (createPostDto.TagId != null)
            {

                foreach (var tagId in createPostDto.TagId)
                {
                    var tag = await _context.Tags.FindAsync(tagId);
                    if (tag == null)
                    {
                        return new CreatePostDto { Content = "Tag bulunamadı" };
                    }
                    tags.Add(tag);

                }
            }


            if (user == null || category == null)
            {
                return new CreatePostDto();
            }
            Post post = new Post();
            post.Author = user;
            post.Title = createPostDto.Title;
            post.Category = category;
            post.Content = createPostDto.Content;
            post.ImageUrl = createPostDto.ImageUrl;
            post.Tags = tags;


            await _context.Posts.AddAsync(post);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return createPostDto;

            }
            return new CreatePostDto();

        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var result = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (result != null)
            {
                _context.Posts.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<GetAllPostDto>> GetAllPostsAsync()
        {
            var result = await _context.Posts.Include(x => x.Tags).Include(p => p.Author).Include(x => x.Category).ToListAsync();

            var postDtos = new List<GetAllPostDto>();


            if (result != null)
            {

                foreach (var post in result)
                {


                    postDtos.Add(new GetAllPostDto
                    {
                        Title = post.Title,
                        Content = post.Content,
                        ImageUrl = post.ImageUrl,
                        CategoryName = post.Category.CategoryName,
                        UserName = post.Author.UserName,
                        CreatedAt = post.CreatedAt,
                        UpdateTime = post.UpdateTime,
                        PostId = post.PostId,

                        TagName = post.Tags.Select(x => x.TagName).ToList()


                    });

                }

                return postDtos;
            }
            return new List<GetAllPostDto>();
        }
        public async Task<GetByIdPostDto> GetByIdPost(int id)
        {
            var result = await _context.Posts.Include(x => x.Tags).Include(p => p.Author).Include(x => x.Category).FirstOrDefaultAsync(x => x.PostId == id);
            if (result != null)
            {
                return new GetByIdPostDto { PostId = result.PostId, Title = result.Title, Content = result.Content, ImageUrl = result.ImageUrl, CategoryName = result.Category.CategoryName, UserId = result.Author.Id, TagName = result.Tags.Select(x => x.TagName).ToList(), CreatedAt = result.CreatedAt.Date.ToString(), UpdateTime = result.UpdateTime };
            }
            return new GetByIdPostDto();
        }

        public async Task<bool> UpdatePostAsync(UpdatePostDto updatePostDto)
        {
            var post = await _context.Posts.Include(x => x.Tags).Include(x => x.Category).FirstOrDefaultAsync(c => c.PostId == updatePostDto.PostId);
            var user = await _context.Users.FindAsync(updatePostDto.UserId);
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == updatePostDto.CategoryName);





            if (post == null || user == null || category == null)
            {
                return false;
            }
            post.Title = updatePostDto.Title;
            post.Content = updatePostDto.Content;
            post.ImageUrl = updatePostDto.ImageUrl;
            post.UpdateTime = DateTime.Now;
            post.Category = category;
            post.Author = user;                    

            post.Tags.Clear();
            foreach (var item in updatePostDto.TagId)
            {
                var tag = await _context.Tags.FindAsync(item);
                if (!post.Tags.Any(p => p.TagId == tag.TagId))
                {
                    post.Tags.Add(tag);
                }

            }



            var success = await _context.SaveChangesAsync();

            return success > 0;
        }
    }
}
