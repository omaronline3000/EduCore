using EduCore.Repository;

namespace EduCore.Services
{
    public class CourseTraineeResultsService
    {
        private readonly ICourseTraineeResultsRepository _courseTraineeResultsRepository;
        public CourseTraineeResultsService(ICourseTraineeResultsRepository courseTraineeResultsRepository)
        {
            _courseTraineeResultsRepository = courseTraineeResultsRepository;
        }
        public List<CrsResult>? GetAll()
        {
            return _courseTraineeResultsRepository.GetAll();
        }
        public CrsResult? GetById(int id)
        {
            return _courseTraineeResultsRepository.GetById(id);
        }
        public CrsResult? GetResultByTidAndCid(int Tid, int Cid)
        {
            return _courseTraineeResultsRepository.GetResultByTidAndCid(Tid, Cid);
        }
        public List<CourseDataToDisplayTraineeResultsViewModel>? GetResultsByTid(int Tid)
        {
            return _courseTraineeResultsRepository.GetResultsByTid(Tid);
        }
        public void AddResult(/* */)
        {
            CrsResult crsResult = new()
            {

            };
            _courseTraineeResultsRepository.AddResult(crsResult);
        }
        public void UpdateResult(/* */)
        {
            CrsResult crsResult = new()
            {

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
