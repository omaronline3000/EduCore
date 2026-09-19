using EduCore.Data;
using EduCore.Models;
using EduCore.Repository;

namespace EduCore.Services
{
    public class DepartmentService
    {
        private readonly APPDbContext _context;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<Department>? GetAll()
        {
            if (_departmentRepository.Exist())
                return _departmentRepository.GetAll();
            else return null;
        }

        public bool Exist(int id)
        {
            return _departmentRepository.Exist(id);
        }
        public bool Exist()
        {
            return _departmentRepository.Exist();
        }
    }
}
