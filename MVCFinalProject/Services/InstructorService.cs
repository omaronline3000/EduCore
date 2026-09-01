using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVCFinalProject.Data;
using MVCFinalProject.Models;
using MVCFinalProject.ViewModels;

namespace MVCFinalProject.Services
{
    public class InstructorService
    {
        private readonly APPDbContext _context;
        public InstructorService()
        {
             _context = new APPDbContext();
            _context.instructors
                .Include(i => i.department)
                .Include(i => i.course)
                .Load();
        }

        public List<Instructor> GetALl()
        {
            return _context.instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return _context.instructors.Find(id);
        }

        public void AddInstructor(AddingInstructorViewModel instructorFromRequest)
        {
           
            Instructor instructor = new()
            {
                Name = instructorFromRequest.Name,
                Address = instructorFromRequest.Address,
                Salary = instructorFromRequest.salary,
                deptId = instructorFromRequest.DepartmentId,
                crsId = instructorFromRequest.CourseId
            };

            _context.instructors.Add(instructor);
            _context.SaveChanges();
        }

        public List<SearchDataViewModel> SearchByName(string Name)
        {
            Name = Name.Replace(" ", "").ToLower();

            var instructorsResults = _context.instructors
                .Where(i => i.Name.Replace(" ","").ToLower() == Name)
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
    }
}
