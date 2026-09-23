using EduCore.Repository;

namespace EduCore.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstructorService _instructorService;
        private readonly CourseService _courseService;
        private readonly DepartmentService _departmentService;
        public InstructorController(InstructorService instructorService, DepartmentService departmentService , CourseService courseService) 
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _departmentService = departmentService;
        
        }

        public IActionResult DashBoard()
        {
            InstructorInfoViewModel model = _instructorService.GetInfo(User);
            return View("InstructorDashboard",model);
        }

        public IActionResult Index()
        {
            var instructors = _instructorService.GetAll();
            return View("ShowAll", instructors);
        }
        
        public IActionResult Details(int id)
        {
            var instructor = _instructorService.GetById(id);
            return View("InstructorDetails", instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddingInstructorViewModel viewModel = new AddingInstructorViewModel();
            viewModel.departments = _departmentService.GetAll();
            viewModel.courses = _courseService.GetAll();
            return View("Add",viewModel);
        }

        [HttpPost]
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
        
        public IActionResult Delete(int id)
        {
            _instructorService.Delete(id);
            return RedirectToAction("Index");
        }


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
    }
}
