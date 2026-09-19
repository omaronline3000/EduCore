using MVCFinalProject.Data;
using MVCFinalProject.Models;

namespace MVCFinalProject.Services
{
    public class DepartmentService
    {
        private readonly APPDbContext _context;
        public DepartmentService(APPDbContext context)
        {
            _context = context;
        }


    }
}
