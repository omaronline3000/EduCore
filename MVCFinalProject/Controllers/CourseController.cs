using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MVCFinalProject.Services;
using MVCFinalProject.ViewModels;

namespace MVCFinalProject.Controllers
{
    public class CourseController : Controller
    {

        [HttpGet]
        public IActionResult Index(int num)
        {
            var Courses = new CourseService().Pagination(num);
            ViewBag.Num = num;
            return View("ShowAllCourses", Courses);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCoursesViewModel CourseViewModel = new AddCoursesViewModel()
            {
                departments = new DepartmentService().GetAll()
            };

            return View("Add", CourseViewModel);
        }
        [HttpPost]
        public IActionResult SaveAdd(AddCoursesViewModel CourseFromReq)
        {
            if (!ModelState.IsValid)
            {
                CourseFromReq.departments = new DepartmentService().GetAll();
                return View("Add", CourseFromReq);
            }
            new CourseService().AddCourse(CourseFromReq);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            new CourseService().RemoveCourse(id);
            return RedirectToAction("Index");
        }

    }
}
