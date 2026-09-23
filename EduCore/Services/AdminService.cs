using System.Security.Claims;

namespace EduCore.Services
{
    public class AdminService
    {
        public AdminInfoViewModel GetInfo(ClaimsPrincipal User)
        {
            return new AdminInfoViewModel()
            {
                Userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Name = User.Identity?.Name,
                Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
            };
        }
    }
}
