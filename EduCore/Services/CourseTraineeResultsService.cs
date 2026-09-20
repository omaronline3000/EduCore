using EduCore.Repository;

namespace EduCore.Services
{
    public class CourseTraineeResultsService
    {
        private readonly ICourseTraineeResultsRepository _courseTraineeResultsRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ITraineeRepository _traineeRepository;
        public CourseTraineeResultsService(ICourseTraineeResultsRepository courseTraineeResultsRepository , ICourseRepository courseRepository , ITraineeRepository traineeRepository)
        {
            _courseTraineeResultsRepository = courseTraineeResultsRepository;
            _courseRepository = courseRepository;
            _traineeRepository = traineeRepository;
        }
        public List<CrsResult>? GetAll()
        {
            return _courseTraineeResultsRepository.GetAll();
        }
        public CrsResult? GetById(int id)
        {
            return _courseTraineeResultsRepository.GetById(id);
        }
        public TraineeCourseDegreeResultcsViewModel? GetResultByTidAndCid(int Tid, int Cid)
        {
            CrsResult? result = _courseTraineeResultsRepository.GetResultByTidAndCid(Tid, Cid);
            return new TraineeCourseDegreeResultcsViewModel()
            {
                TName = result?.trainee.Name,
                CName = result?.course.Name,
                Degree = result?.Degree,
                State = result?.Degree >= result?.course.minDegree ? "Successed" : "Failed",
                Color = result?.Degree >= result?.course.minDegree ? "Green" : "Red"
            };
        }
        public DisplayTraineeCoursesDegreeViewModel? GetResultsByTid(int Tid)
        {
            string? Name = _traineeRepository.GetById(Tid)?.Name;
            return new DisplayTraineeCoursesDegreeViewModel()
            {
                TraineeName = Name,
                CourseData = _courseTraineeResultsRepository.GetResultsByTid(Tid)
            };
        }
        public DisplayCourseWithTraineeDataViewModel? GetResultsByCid(int Cid)
        {
            string? Name = _courseRepository.GetById(Cid)?.Name;
            return new DisplayCourseWithTraineeDataViewModel()
            {
                CourseTitle = Name,
                TraineeData = _courseTraineeResultsRepository.GetResultsByCid(Cid)
            };
        }
        public void AddResult(AddResultViewModel result)
        {
            CrsResult crsResult = new()
            {
                Degree = result.Degree,
                traineeId = result.traineeId,
                crsId = result.crsId
            };
            _courseTraineeResultsRepository.AddResult(crsResult);
        }
        public void UpdateResult(AddResultViewModel result , int id)
        {
            CrsResult crsResult = new()
            {
                Id = id,
                Degree = result.Degree,
                traineeId = result.traineeId,
                crsId = result.crsId
            };
            _courseTraineeResultsRepository.UpdateResult(crsResult);
        }
        public void DeleteResult(int id)
        {

            _courseTraineeResultsRepository.DeleteResult(id);
        }
        public void Save()
        {
            _courseTraineeResultsRepository.Save();
        }
    }
}
