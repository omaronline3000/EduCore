using EduCore.DTO;
using System.Data;

namespace EduCore.Repository
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

        public List<Course> GetAll()
        {
            return _context.courses.ToList();
        }


        public List<Course>? GetByTid(int id)
        {
            return _context.crsResults
                .Where(cr => cr.traineeId == id)
                .Select(cr => cr.course)
                .ToList();
        }


        public List<Course> GetPage(int pageNumber, int pageSize)
        {
            return _context.courses
                .Include(c => c.instructors)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToList();
        }

        //public Course? GetCourseByInstructorId(int id)
        //{
        //    return _context.courses.FirstOrDefault(c => c.instructors.)
        //}

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

        public bool Exist(int id)
        {
            return _context.courses.Any(c => c.Id == id);
        }
        public bool Exist()
        {
            return _context.courses.Any();
        }

        public DisplayCourseWithItsTraineeResults GetCourseWithTraineeResults(Course course)
        {
            var CourseResults = new DisplayCourseWithItsTraineeResults()
            {
                CourseTitle = course.Name,
                TraineeData = _context.crsResults
                    .Where(crs => crs.crsId == course.Id)
                    .Select(crs => new TraineeDataToDisplayInCourseResultViewModel()
                    {
                        Name = crs.trainee.Name,
                        Degree = crs.Degree,
                        Color = crs.Degree >= crs.course.minDegree ? "Green" : "Red",
                        State = crs.Degree >= crs.course.minDegree ? "Successed" : "Failed"
                    }).ToList()
            };
            return CourseResults;
        }


        public List<CoursesDataByDepartmetnDTO> GetCoursesByDeptId(int deptId)
        {

            return _context.courses
                    .Where(c => c.deptId == deptId)
                    .Select(c => new CoursesDataByDepartmetnDTO
                        {
                            Name = c.Name,
                            Id = c.Id
                        })
                    .ToList();
         }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
