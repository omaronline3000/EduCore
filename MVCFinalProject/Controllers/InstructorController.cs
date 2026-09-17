using MVCFinalProject.Repository;

namespace MVCFinalProject.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        public InstructorController(IInstructorRepository instructorRepository , IDepartmentRepository departmentRepository , ICourseRepository courseRepository) 
        { 
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
            _departmentRepository = departmentRepository;
        
        }
        public IActionResult Index()
        {
            var instructors = _instructorRepository.GetAll();
            return View("ShowAll", instructors);
        }
        
        public IActionResult Details(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            return View("InstructorDetails", instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddingInstructorViewModel viewModel = new AddingInstructorViewModel();
            viewModel.departments = _departmentRepository.GetAll();
            viewModel.courses = _courseRepository.GetAll();
            return View("Add",viewModel);
        }

        [HttpPost]
        public IActionResult SaveAdd(AddingInstructorViewModel instructorFromRequest)
        {
            if (!ModelState.IsValid)
            {
                instructorFromRequest.departments = _departmentRepository.GetAll();
                instructorFromRequest.courses = _courseRepository.GetAll();
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
