using Microsoft.AspNetCore.Authorization;
using MVCFinalProject.Repository;

namespace MVCFinalProject.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly CourseService _service;
        public CourseController(ICourseRepository courseRepository , IDepartmentRepository departmentRepository , CourseService service)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
            _service = service;
        }
        [HttpGet]
        public IActionResult Index(int num)
        {
            var Courses = _service.Pagination(num);
            ViewBag.Num = num;
            return View("ShowAllCourses", Courses);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCoursesViewModel CourseViewModel = new AddCoursesViewModel()
            {
                departments = _departmentRepository.GetAll()
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
                CourseFromReq.departments = _departmentRepository.GetAll();
                return View("Add", CourseFromReq);
            }
            _service.AddCourse(CourseFromReq);
            return RedirectToAction("Index");
        }
      //  [HttpPost]
      // Remote Validation
        public IActionResult ValidateDegree(int minDegree , int Degree)
        {
            if(Degree <= minDegree)
            {
                return Json(false);
            }
            return Json(true);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult CouresResults(int id)
        {
            var data = _service.CourseDegrees(id);
            return View("CourseTraineeResults", data);
        }
        public IActionResult GetCoursesByDept(int deptId)
        {
            var result = _service.GetCoursesByDeptId(deptId);
            return Json(result);
        }

    }
}
