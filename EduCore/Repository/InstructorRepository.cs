namespace MVCFinalProject.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly APPDbContext _context;
        public InstructorRepository(APPDbContext context)
        {
            _context = context;
        }

        public void Add(Instructor ins)
        {

            _context.instructors.Add(ins);
        }

        public List<Instructor>? GetAll()
        {
            return _context.instructors.ToList();
        }
        public Instructor? GetById(int id)
        {
            return _context.instructors.Find(id);
        }

        public void Update(Instructor ins)
        {
            _context.instructors.Update(ins);
        }
        public void Delete(int id)
        {
            var instructor = _context.courses.Find(id);
            if (instructor is not null) instructor.IsDeleted = true;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
