namespace MVCFinalProject.Repository
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
        public void Delete(Trainee tar)
        {
            var Trainee = _context.courses.Find(tar.Id);
            if (Trainee is not null) Trainee.IsDeleted = true;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
