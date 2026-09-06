using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing.Tree;
using MVCFinalProject.Services;

namespace MVCFinalProject.Controllers
{
    public class TraineeController : Controller
    {
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
