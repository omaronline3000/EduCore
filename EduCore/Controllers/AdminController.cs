using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly CourseService _courseService;
        private readonly AdminService _adminService;
        private readonly InstructorService _instructorService;
        public AdminController(CourseService courseService , AdminService adminService , InstructorService instructorService)
        {
            _courseService = courseService;
            _adminService = adminService;
            _instructorService = instructorService;
        }
        [HttpGet]
        public IActionResult DashBoard()
        {
            AdminInfoViewModel model = _adminService.GetInfo(User);
            return View("AdminDashboard", model);
        }

        
        [HttpGet]
        public IActionResult AssignInstructor()
        {
            ViewBag.courses = _courseService.GetAll();
            ViewBag.instructors = _instructorService.GetAll();
            return View("AssignInstructor");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignInstructor(AssignInstructorViewModel dataFromReq)
        {
            if (ModelState.IsValid)
            {
                bool state = _courseService.AssignInstructor(dataFromReq);
                if (!state) ModelState.AddModelError("", "Instructor or Course is not exist");
                else RedirectToAction("AssignInstructor");
            }
            ViewBag.courses = _courseService.GetAll();
            ViewBag.instructors = _instructorService.GetAll();
            return View("AssignInstructor",dataFromReq);
        }

    }
}
