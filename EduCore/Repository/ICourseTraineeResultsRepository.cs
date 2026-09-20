namespace EduCore.Repository
{
    public interface ICourseTraineeResultsRepository
    {


        // CRUD
        List<CrsResult>? GetAll();
        CrsResult? GetById(int id);
        CrsResult? GetResultByTidAndCid(int Tid, int Cid);
        List<CourseDataToDisplayTraineeResultsViewModel>? GetResultsByTid(int Tid);
        List<TraineeDataForCourseViewModel>? GetResultsByCid(int Cid);
        void AddResult(CrsResult crsResult);
        void UpdateResult(CrsResult crsResult);
        void DeleteResult(int id);
        void Save();
        // Main Features
   

    }
}
