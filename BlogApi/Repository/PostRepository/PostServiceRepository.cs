using BlogApi.Dtos.PostDtos;
using BlogApi.Models;

namespace BlogApi.Repository.PostRepository
{
    public class PostServiceRepository : IPostServiceRepository
    {
        private readonly Context _context;
        public PostServiceRepository(Context context) {
        _context = context;
        }
        public async Task<CreatePostDto> CreatePostAsync(CreatePostDto createPostDto)
        {
          

            Post post = new Post();
            post.Author.Id = createPostDto.UserId;
            post.Title = createPostDto.Title;
            post.Category.CategoryId=createPostDto.CategoryId;
            post.Content=createPostDto.Content;
            post.ImageUrl=createPostDto.ImageUrl;
           
            post.CreatedAt=DateTime.Now;
            
           await _context.Posts.AddAsync(post);
          
           var result = await _context.SaveChangesAsync(); 
            if(result>0)
            {
                return createPostDto;
            
            }
            
            return new CreatePostDto();

           

         
        }

        public Task<bool> DeletePostAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllPostDto>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdPostDto> GetByIdPost(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdatePostDto> UpdatePostAsync(UpdatePostDto updatePostDto)
        {
            throw new NotImplementedException();
        }
    }
}
