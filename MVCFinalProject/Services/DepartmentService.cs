using MVCFinalProject.Data;
using MVCFinalProject.Models;

namespace MVCFinalProject.Services
{
    public class DepartmentService
    {
        private readonly APPDbContext _context;
        public DepartmentService()
        {
            _context = new APPDbContext();
        }

        public List<Department> GetAll()
        {
            return _context.departments.ToList();
        }
    }
}
