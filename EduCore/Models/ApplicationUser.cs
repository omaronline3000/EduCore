using Microsoft.AspNetCore.Identity;

namespace EduCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
