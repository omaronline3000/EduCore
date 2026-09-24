using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace EduCore.Controllers
{
    public class ResultController : Controller
    {
        private readonly CourseTraineeResultsService _courseTraineeResultsService;
        private readonly InstructorService _instructorService;
        public ResultController(CourseTraineeResultsService courseTraineeResultsService , InstructorService instructorService)
        {
            _courseTraineeResultsService = courseTraineeResultsService;
            _instructorService = instructorService;
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
        [HttpGet]
        public IActionResult AddResult()
        {
            return View("AddResult");
        }
        [HttpPost]
        public IActionResult AddResult(AddResultViewModel data)
        {
            if (ModelState.IsValid)
            {
                int state = _courseTraineeResultsService.AddResult(data);
                if (state == -1) ModelState.AddModelError("", "The Trainee or The Course Is not Exist");
                else if(state == 0) ModelState.AddModelError("", "The Trainee Already has Result for this Course");
                else return RedirectToAction("AddResult");
            }
            return View("AddResult", data);
        }

        public IActionResult Delete(int id)
        {
            _courseTraineeResultsService.DeleteResult(id);
            return RedirectToAction("Index");
        }
    }
}
