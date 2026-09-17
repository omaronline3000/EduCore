
using MVCFinalProject.Repository;

namespace MVCFinalProject.Controllers
{ 
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository _traineeRepository;
        public TraineeController(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowResult(int id, int CrsId)
        {
            var result = new TraineeService().GetResult(id, CrsId);
            return View("ShowTraineeResults", result);
        }

        public IActionResult AllResults(int id)
        {
            var results = new TraineeService().getAllResults(id);
            return View("ShowResults", results);
        }
    }
}
