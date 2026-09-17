using Microsoft.AspNetCore.Identity;

namespace MVCFinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
