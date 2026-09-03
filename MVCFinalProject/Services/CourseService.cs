using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using MVCFinalProject.ViewModels;

namespace MVCFinalProject.Services
{
    public class CourseService
    {
        private readonly APPDbContext _context;
        public CourseService() { 
            _context = new APPDbContext();
            _context.courses
                .Include(c => c.department)
                .Include(c => c.instructors)
                .Load();
        }

        public List<Course> GetAll()
        {
            return _context.courses.ToList();
        }
       public List<Course> Pagination(int PageNumber)
        {
            const int pageSize = 2;

            return _context.courses
                .Skip(pageSize * PageNumber)
                .Take(pageSize)
                .ToList();
        } 
        public void AddCourse(AddCoursesViewModel CourseFromReq)
        {
            var course = new Course()
            {
                Name = CourseFromReq.Name,
                Degree = CourseFromReq.Degree,
                minDegree = CourseFromReq.minDegree,
                Hourse = CourseFromReq.Hourse,
                deptId = CourseFromReq.DeptId
            };
            _context.courses.Add(course);
            _context.SaveChanges();
        }

        public void RemoveCourse(int id)
        {
            var course = _context.courses.Find(id);
            course?.IsDeleted = true;
            _context.SaveChanges();

        }
    }
}
