using EduCore.Repository;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;

namespace EduCore.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstructorService _instructorService;
        private readonly CourseService _courseService;
        private readonly DepartmentService _departmentService;
        private readonly TraineeService _traineeService;
        public InstructorController(InstructorService instructorService, DepartmentService departmentService , CourseService courseService , TraineeService traineeService) 
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _departmentService = departmentService;
            _traineeService = traineeService;
        }
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public IActionResult DashBoard()
        {
            InstructorInfoViewModel model = _instructorService.GetInfo(User);
            return View("InstructorDashboard",model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            var instructors = _instructorService.GetAll();
            return View("ShowAll", instructors);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var instructor = _instructorService.GetById(id);
            return View("InstructorDetails", instructor);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            AddingInstructorViewModel viewModel = new AddingInstructorViewModel();
            viewModel.departments = _departmentService.GetAll();
            viewModel.courses = _courseService.GetAll();
            return View("Add",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult SaveAdd(AddingInstructorViewModel instructorFromRequest)
        {
            if (!ModelState.IsValid)
            {
                instructorFromRequest.departments = _departmentService.GetAll();
                instructorFromRequest.courses = _courseService.GetAll();
                return View("Add",instructorFromRequest);
            }
                
            _instructorService.AddInstructor(instructorFromRequest);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _instructorService.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        // TODO: edit to make it search by id not name
        public IActionResult Search(string search)
        {
            var result = _instructorService.SearchByName(search);
            if(result.Count < 1)
            {
                return Content("There is not instructor with this name");
            }
            else
                return View("SearchResult", result);
        }
        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public IActionResult GetTrainees()
        {
            string uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var instructor = _instructorService.GetByUserId(uid);
            var trainees = _traineeService.GetByInstructorId(instructor.Id);
            return View("GetTrainees", trainees);
        }
    }
}
