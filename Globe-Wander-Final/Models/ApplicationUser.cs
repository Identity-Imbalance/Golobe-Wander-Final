using Microsoft.AspNetCore.Identity;

namespace Globe_Wander_Final.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ImageUrl { get; set; }
    }
}
