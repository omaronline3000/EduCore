
using EduCore.Repository;

namespace EduCore.Controllers
{ 
    public class TraineeController : Controller
    {
        private readonly TraineeService _trineeService;
        public TraineeController(TraineeService traineeService)
        {
            _trineeService = traineeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowResult(int id, int CrsId)
        {
            var result = _trineeService.GetResult(id, CrsId);
            return View("ShowTraineeResults", result);
        }

        public IActionResult AllResults(int id)
        {
            var results = _trineeService.getAllResults(id);
            return View("ShowResults", results);
        }
    }
}
