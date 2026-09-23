namespace EduCore.Repository
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
            return _context.instructors
                .Include(i => i.department)
                .Include(i => i.course)
                .ToList();
        }
        public Instructor? GetById(int id)
        {
            return _context.instructors
                .Include(i => i.course)
                .Include(i => i.department)
                .FirstOrDefault(i => i.Id == id);
        }

        public Instructor? GetByUserId(string id)
        {
            return _context.instructors.FirstOrDefault(i => i.UserId == id);
        }

        public List<SearchDataViewModel> GetInstructorsByName(string name)
        {
            var instructorsResults = _context.instructors
                .Where(i => i.Name.Replace(" ", "").ToLower() == name)
                .Select(
                (i) => new SearchDataViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Address = i.Address,
                    Salary = i.Salary,
                    department = i.department.Name,
                    course = i.course.Name
                })
                .ToList();

            return instructorsResults;
        }


        public void Update(Instructor ins)
        {
            _context.instructors.Update(ins);
        }
        public void Delete(int id)
        {
            var instructor = _context.instructors.Find(id);
            if (instructor is not null) instructor.IsDeleted = true;
        }

        public bool Exist(int id)
        {
            return _context.instructors.Any(c => c.Id == id);
        }

        public bool Exist()
        {
            return _context.instructors.Any();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
