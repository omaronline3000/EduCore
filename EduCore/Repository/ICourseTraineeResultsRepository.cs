namespace EduCore.Repository
{
    public interface ICourseTraineeResultsRepository
    {


        // CRUD
        List<CrsResult>? GetAll();
        CrsResult? GetById(int id);
        CrsResult? GetResultByTidAndCid(int Tid, int Cid);
        List<CourseDataToDisplayTraineeResultsViewModel>? GetResultsByTid(int Tid);
        void AddResult(CrsResult crsResult);
        void UpdateResult(CrsResult crsResult);
        void DeleteResult(int id);
        void Save();
        // Main Features
   

    }
}
