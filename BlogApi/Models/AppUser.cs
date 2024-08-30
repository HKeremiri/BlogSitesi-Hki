using Microsoft.AspNetCore.Identity;

namespace BlogApi.Models
{
    public class AppUser:IdentityUser<string>
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FullName { get; set; }
    }
}
