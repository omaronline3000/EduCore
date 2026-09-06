using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using MVCFinalProject.ViewModels;

namespace MVCFinalProject.Services
{
    public class TraineeService
    {
        private readonly APPDbContext _context;
        public TraineeService()
        {
            _context = new APPDbContext();
        }
        //public void GetAll()
        //{

        //}
        public TraineeCourseDegreeResultcsViewModel? GetResult(int Tid , int Cid)
        {
            var crsResult = _context.crsResults.FirstOrDefault(crs => crs.traineeId == Tid && crs.crsId == Cid);
            if (crsResult is null) return null;

            _context.Entry(crsResult).Reference(crs => crs.trainee).Load();
            _context.Entry(crsResult).Reference(crs => crs.course).Load();
            return new TraineeCourseDegreeResultcsViewModel()
            {
                TName = crsResult.trainee.Name,
                CName = crsResult.course.Name,
                Degree = crsResult.Degree,
                Color = crsResult.Degree >= crsResult.course.minDegree ? "Green" : "Red",
                State = crsResult.Degree >= crsResult.course.minDegree ? "Successed" : "Failed"
            };

        }
        public DisplayTraineeCoursesDegreeViewModel? getAllResults(int Tid)
        {
            var trainee = _context.trainees.Find(Tid);
            if (trainee is null)
                return null;

            var CourseResults = new DisplayTraineeCoursesDegreeViewModel();
            CourseResults.TraineeName = trainee.Name;

            CourseResults.CourseData = _context.crsResults
                .Where(crs => crs.traineeId == Tid)
                .Select(crs => 
                new CourseDataToDisplayTraineeResultsViewModel()
                {
                    Name = crs.course.Name,
                    Degree = crs.Degree,
                    State = crs.Degree >= crs.course.minDegree ? "Successed" : "Failed"
                }).ToList();

            return CourseResults;
        }
    }
}
