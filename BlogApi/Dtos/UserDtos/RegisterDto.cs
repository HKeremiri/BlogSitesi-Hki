using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.UserDtos
{
    public class RegisterDto
    {
        [Required]
        public string FullName { get; set; }     
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
