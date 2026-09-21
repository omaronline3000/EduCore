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
            return _context.trainees
                .Include(t => t.department)
                .ToList();
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


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
