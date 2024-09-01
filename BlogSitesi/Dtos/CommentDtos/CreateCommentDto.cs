using System.ComponentModel.DataAnnotations;

namespace BlogSitesi.Dtos.CommentDtos
{
	public class CreateCommentDto
	{
		[Required(ErrorMessage = "Yorum alanı boş bırakılamaz")]
	
		public string Content { get; set; }
		[Required]
		public string UserId { get; set; }
		[Required]
		public int PostId { get; set; }
	}
}
