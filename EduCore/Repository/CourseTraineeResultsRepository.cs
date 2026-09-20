using Microsoft.AspNetCore.Http.HttpResults;

namespace EduCore.Repository
{
    public class CourseTraineeResultsRepository : ICourseTraineeResultsRepository
    {
        private readonly APPDbContext _context;
        public CourseTraineeResultsRepository(APPDbContext context)
        {
            _context = context;
        }
        public List<CrsResult>? GetAll()
        {
            return _context.crsResults
                    .Include(crs => crs.course)
                    .Include(crs => crs.trainee)
                    .ToList();
        }
        public CrsResult? GetById(int id)
        {
            return _context.crsResults
                    .Include(crs => crs.course)
                    .Include(crs => crs.trainee)
                    .FirstOrDefault(crs => crs.Id == id);
        }

        public CrsResult? GetResultByTidAndCid(int Tid, int Cid)
        {
            return _context.crsResults
                .Include(cr => cr.trainee)
                .Include(cr => cr.course)
                .FirstOrDefault(crs => crs.traineeId == Tid && crs.crsId == Cid);
        }
        public List<CourseDataToDisplayTraineeResultsViewModel>? GetResultsByTid(int Tid)
        {
            return _context.crsResults
                .Where(crs => crs.traineeId == Tid)
                .Select(crs =>
                new CourseDataToDisplayTraineeResultsViewModel()
                {
                    Name = crs.course.Name,
                    Degree = crs.Degree,
                    State = crs.Degree >= crs.course.minDegree ? "Successed" : "Failed"
                }).ToList();
        }
        public List<TraineeDataForCourseViewModel>? GetResultsByCid(int Cid)
        {
            return _context.crsResults
                .Where(crs => crs.crsId == Cid)
                .Select(crs => 
                new TraineeDataForCourseViewModel()
                {
                    Name = crs.trainee.Name,
                    Degree = crs.Degree,
                    State = crs.Degree >= crs.course.minDegree ? "Successed" : "Failed",
                    Color = crs.Degree >= crs.course.minDegree ? "Green" : "Red"
                }).ToList();
        }
        public void AddResult(CrsResult crsResult)
        {
            _context.crsResults.Add(crsResult);
        }
        public void UpdateResult(CrsResult crsResult)
        {
            _context.crsResults.Update(crsResult);
        }
        public void DeleteResult(int id)
        {
            var crsResult = _context.crsResults.Find(id);
            if (crsResult is not null)
                crsResult.IsDeleted = true;
               
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        
    }
}
