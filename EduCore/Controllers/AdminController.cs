using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly CourseService _courseService;
        private readonly AdminService _adminService;
        public AdminController(CourseService courseService , AdminService adminService)
        {
            _courseService = courseService;
            _adminService = adminService;
        }
        public IActionResult DashBoard()
        {
            AdminInfoViewModel model = _adminService.GetInfo(User);
            return View("AdminDashboard", model);
        }
        
    }
}
