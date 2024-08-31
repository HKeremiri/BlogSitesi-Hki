using BlogApi.Dtos.CommentDto;
using BlogApi.Dtos.PostDtos;
using BlogApi.Dtos.TagDtos;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repository.CommentRepository
{
    public class CommentServiceRepository : ICommentServiceRepository
    {
        private readonly Context _context;

        public CommentServiceRepository(Context context)
        {
            _context = context;
        }

       
        public async Task<bool> CreateCommentAsync(CreateCommentDto createCategoryDto)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p=>p.PostId == createCategoryDto.PostId);
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id == createCategoryDto.UserId);

            if(user == null || post ==null) { 
            return false;
            }
            var result = _context.Comments.Add(new Comment
            {
                Content = createCategoryDto.Content,
                Post = post,
                User = user,
                CreateTime = DateTime.Now         
            }) ;
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var result = await _context.Comments.FirstOrDefaultAsync(p => p.CommentId == id);
            if (result != null)
            {
                _context.Comments.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<GetAllCommentDto>> GetAllCommentAsync()
        {
            var result = await _context.Comments.Include(x => x.User).Include(p => p.Post).ToListAsync();

            var commentDtos = new List<GetAllCommentDto>();


            if (result != null)
            {

                foreach (var comment in result)
                {


                    commentDtos.Add(new GetAllCommentDto
                    {
                      CommentId=comment.CommentId,
                      Content=comment.Content,
                      CreateTime=comment.CreateTime,                      
                     UpdateTime=comment.UpdateTime,
                      PostId=comment.Post.PostId,
                      UserName=comment.User.UserName
                    


                    });

                }

                return commentDtos;
            }
            return new List<GetAllCommentDto>();
        }

        public async Task<GetByIdCommentDto> GetByIdCommentAsync(int id)
        {
            var result = await _context.Comments.Include(x => x.Post).Include(p => p.User).FirstOrDefaultAsync(x => x.CommentId == id);
            if (result != null)
            {
                return new GetByIdCommentDto { CommentId=result.CommentId, Content=result.Content, CreateTime=result.CreateTime, UpdateTime=result.UpdateTime, PostId=result.Post.PostId, UserName=result.User.UserName  };
            }
            return new GetByIdCommentDto { Content="Yorum Bulunamadı"};
        }    

        public async Task<bool> UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == updateCommentDto.CommentId);
            if (comment == null)
            {
                return false;
            }


            comment.Content = updateCommentDto.Content; 
            comment.UpdateTime = DateTime.Now;
            var success = await _context.SaveChangesAsync();
            return success > 0;
        }
    }
}
