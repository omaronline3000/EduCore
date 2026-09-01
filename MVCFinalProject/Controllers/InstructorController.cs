using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using MVCFinalProject.ViewModels;
using MVCFinalProject.Services;


namespace MVCFinalProject.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            var instructors = new InstructorService().GetALl();
            return View("ShowAll", instructors);
        }
        
        public IActionResult Details(int id)
        {
            var instructor = new InstructorService().GetById(id);
            return View("InstructorDetails", instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddingInstructorViewModel viewModel = new AddingInstructorViewModel();
            viewModel.departments = new DepartmentService().GetAll();
            viewModel.courses = new CourseService().GetAll();
            return View("Add",viewModel);
        }

        [HttpPost]
        public IActionResult SaveAdd(AddingInstructorViewModel instructorFromRequest)
        {
            if (!ModelState.IsValid)
            {
                instructorFromRequest.departments = new DepartmentService().GetAll();
                instructorFromRequest.courses = new CourseService().GetAll();
                return View("Add",instructorFromRequest);
            }
                

            new InstructorService().AddInstructor(instructorFromRequest);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        // TODO: edit to make it search by id not name
        public IActionResult Search(string search)
        {
            var result = new InstructorService().SearchByName(search);
            if(result.Count < 1)
            {
                return Content("There is not instructor with this name");
            }
            else
                return View("SearchResult", result);
        }
    }
}
