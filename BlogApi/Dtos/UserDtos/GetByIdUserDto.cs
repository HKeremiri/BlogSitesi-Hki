using System.ComponentModel.DataAnnotations;

namespace BlogApi.Dtos.UserDtos
{
    public class GetByIdUserDto
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

    }
}
