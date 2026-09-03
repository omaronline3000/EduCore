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
            if (CourseFromReq.DeptId == -1)
            {
                ModelState.AddModelError("DeptId", "Yo Should Choose Department");
            }

            if (!ModelState.IsValid)
            {
                CourseFromReq.departments = new DepartmentService().GetAll();
                return View("Add", CourseFromReq);
            }
            new CourseService().AddCourse(CourseFromReq);
            return RedirectToAction("Index");
        }
      //  [HttpPost]
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
            new CourseService().RemoveCourse(id);
            return RedirectToAction("Index");
        }

    }
}
