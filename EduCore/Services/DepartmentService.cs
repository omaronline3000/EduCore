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
            _departmentRepository.Save();
        }
        public Department? GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public void Update(Department dep)
        {
            _departmentRepository.Update(dep);
            _departmentRepository.Save();
        }
        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
            _departmentRepository.Save();
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
