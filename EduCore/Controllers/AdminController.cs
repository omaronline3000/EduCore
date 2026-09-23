using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly CourseService _courseService;
        public AdminController(CourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult DashBoard()
        {
            return View("AdminDashboard");
        }
        
    }
}
