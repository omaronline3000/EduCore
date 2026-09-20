namespace EduCore.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly APPDbContext _context;
        public TraineeRepository(APPDbContext context)
        {
            _context = context;
        }

        public void Add(Trainee tra)
        {

            _context.trainees.Add(tra);
        }

        public List<Trainee>? GetAll()
        {
            return _context.trainees.ToList();
        }
        public Trainee? GetById(int id)
        {
            return _context.trainees.Find(id);
        }

        public void Update(Trainee tar)
        {
            _context.trainees.Update(tar);
        }
        public void Delete(int id)
        {
            var Trainee = _context.trainees.Find(id);
            if (Trainee is not null) Trainee.IsDeleted = true;
        }


        public bool Exist(int id)
        {
            return _context.trainees.Any(c => c.Id == id);
        }

        public bool Exist()
        {
            return _context.trainees.Any();
        }


        public CrsResult? GetResult(int Tid, int Cid)
        {
            return _context.crsResults
                .Include(cr => cr.trainee)
                .Include(cr => cr.course)
                .FirstOrDefault(crs => crs.traineeId == Tid && crs.crsId == Cid);
        }
        public List<CourseDataToDisplayTraineeResultsViewModel>? getAllResults(int Tid)
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
