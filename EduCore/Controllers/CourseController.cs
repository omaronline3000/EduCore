using Microsoft.AspNetCore.Authorization;
using EduCore.Repository;

namespace EduCore.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly DepartmentService _departmentService;
        private readonly InstructorService _instructorService;
        public CourseController(CourseService courseService , 
            DepartmentService departmentService,
            InstructorService instructorService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
            _instructorService = instructorService;
        }

        [HttpGet]
        public IActionResult Index(int num=0)
        {
            var Courses = _courseService.Pagination(num);
            ViewBag.Num = num;
            return View("ShowAllCourses", Courses);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCoursesViewModel CourseViewModel = new AddCoursesViewModel()
            {
                departments = _departmentService.GetAll()
            };

            return View("Add", CourseViewModel);
        }
        [HttpPost]
        public IActionResult SaveAdd(AddCoursesViewModel CourseFromReq)
        {
            if (CourseFromReq.DeptId == -1)
            {
                ModelState.AddModelError("DeptId", "Yo Should Choose Department");
            }

            if (!ModelState.IsValid)
            {
                CourseFromReq.departments = _departmentService.GetAll();
                return View("Add", CourseFromReq);
            }
            _courseService.AddCourse(CourseFromReq);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetCoursesByDept(int deptId)
        {
            var result = _courseService.CoursesByDeptId(deptId);
            return Json(result);
        }

        



        // Remote Validation
        public IActionResult ValidateDegree(int minDegree, int Degree)
        {
            if (Degree <= minDegree)
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
