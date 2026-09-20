using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class ResultController : Controller
    {
        private readonly CourseTraineeResultsService _courseTraineeResultsService;
        public ResultController(CourseTraineeResultsService courseTraineeResultsService)
        {
            _courseTraineeResultsService = courseTraineeResultsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowResult(int Tid, int CrsId)
        {
            var result = _courseTraineeResultsService.GetResultByTidAndCid(Tid, CrsId);
            return View("ShowTraineeResults", result);
        }

        public IActionResult ResultsForT(int Tid)
        {
            var results = _courseTraineeResultsService.GetResultsByTid(Tid);
            return View("ShowResults", results);
        }

        public IActionResult ResultsForC(int Cid) {
            var results = _courseTraineeResultsService.GetResultsByCid(Cid);
            return View("ShowResultsByCourse", results);
        }
    }
}
