using EduCore.Data;
using EduCore.Models;
using EduCore.Repository;

namespace EduCore.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<Department>? GetAll()
        {
            if (Exist())
                return _departmentRepository.GetAll();
            else return null;
        }

        public void AddDepartment(Department dep)
        {

            _departmentRepository.Add(dep);
        }
        public Department? GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public void Update(Department dep)
        {
            _departmentRepository.Update(dep);
        }
        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _departmentRepository.Exist(id);
        }
        public bool Exist()
        {
            return _departmentRepository.Exist();
        }
        public void Save()
        {
            _departmentRepository.Save();
        }
    }
}
