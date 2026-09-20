
using EduCore.Repository;

namespace EduCore.Controllers
{ 
    public class TraineeController : Controller
    {
        private readonly TraineeService _trineeService;
        private readonly CourseTraineeResultsService _courseTraineeResultsService;
        public TraineeController(TraineeService traineeService , CourseTraineeResultsService courseTraineeResultsService)
        {
            _trineeService = traineeService;
            _courseTraineeResultsService = courseTraineeResultsService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
