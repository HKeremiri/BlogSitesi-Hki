using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        [Required]
        public string Id { get; set; }
       
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        
        public string Password { get; set; }
        [Required]
        public string OldPassword  { get; set; }
    }
}
