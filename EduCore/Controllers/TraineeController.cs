
using EduCore.Repository;
using System.Security.Claims;

namespace EduCore.Controllers
{ 
    public class TraineeController : Controller
    {
        private readonly TraineeService _trineeService;
        private readonly CourseTraineeResultsService _courseTraineeResultsService;
        private readonly DepartmentService _departmentService;
        private readonly CourseService _courseService;
        public TraineeController(TraineeService traineeService , 
            CourseTraineeResultsService courseTraineeResultsService,
            DepartmentService departmentService,
            CourseService courseService)
        {
            _trineeService = traineeService;
            _courseTraineeResultsService = courseTraineeResultsService;
            _departmentService = departmentService;
            _courseService = courseService;
        }

        public IActionResult DashBoard()
        {
            TraineeInfoViewModel model = _trineeService.GetInfo(User);
            return View("TraineeDashboard",model);
        }

        public IActionResult GetCourses()
        {
            var UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var trainee = _trineeService.GetByUserId(UserId);
            var courses = _courseService.GetByTraineeId(trainee.Id);
            return View("GetCourses", courses);
        }

        public IActionResult Index()
        {
            var trainees = _trineeService.GetAll();
            return View("ShowAll",trainees);
        }

        //public IActionResult Details()
        //{
        //    return 
        //}

        [HttpGet]
        public IActionResult Add()
        {
            AddingTraineeViewModel viewModel = new AddingTraineeViewModel()
            {
                Departments = _departmentService.GetAll()
            };
            return View("Add",viewModel);
        }
        [HttpPost]
        public IActionResult Add(AddingTraineeViewModel traineeViewModel)
        {
            if (traineeViewModel.depId == -1)
                ModelState.AddModelError("depId", "You Should Choose Department");
            if (ModelState.IsValid)
            {
                _trineeService.AddTrainee(traineeViewModel);
                return RedirectToAction("Index");
            }
            return View("Add",traineeViewModel);
        }
        public IActionResult Delete(int id)
        {
            _trineeService.DeleteTrainee(id);
            return RedirectToAction("Index");
        }

    }
}
