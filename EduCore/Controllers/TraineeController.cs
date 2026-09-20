
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
        public IActionResult ShowResult(int id, int CrsId)
        {
            var result = _courseTraineeResultsService.GetResultByTidAndCid(id, CrsId);
            return View("ShowTraineeResults", result);
        }

        public IActionResult AllResults(int id)
        {
            var results = _courseTraineeResultsService.GetResultsByTid(id);
            return View("ShowResults", results);
        }
    }
}
