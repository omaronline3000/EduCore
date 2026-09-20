using Microsoft.EntityFrameworkCore;
using EduCore.Data;
using EduCore.Models;
using EduCore.ViewModels;
using EduCore.Repository;

namespace EduCore.Services
{
    public class TraineeService
    {
        private readonly ITraineeRepository _traineeRepository;
        public TraineeService(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
        }

        public TraineeCourseDegreeResultcsViewModel? GetResult(int Tid , int Cid)
        {
            var crsResult = _traineeRepository.GetResult(Tid, Cid);
            if (crsResult is null) return null;
            else 
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
            var trainee = _traineeRepository.GetById(Tid);
            if (trainee is null)
                return null;

            var CourseResults = new DisplayTraineeCoursesDegreeViewModel();
            CourseResults.TraineeName = trainee.Name;

            CourseResults.CourseData = _traineeRepository.getAllResults(Tid);

            return CourseResults;
        }
    }
}
