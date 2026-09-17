using System.Data;

namespace MVCFinalProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly APPDbContext _context;

        public CourseRepository(APPDbContext context)
        {
            _context = context;
        }

        public void Add(Course crs)
        {
            _context.courses.Add(crs);
        }

        public List<Course>? GetAll()
        {
            return _context.courses.ToList();
        }
        public Course? GetById(int id)
        {
            return _context.courses.Find(id);
        }

        public void Update(Course crs)
        {
            _context.courses.Update(crs);
        }
        public void Delete(int id)
        {
            var course = _context.courses.Find(id);
            if (course is not null) course.IsDeleted = true;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
