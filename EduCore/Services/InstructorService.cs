using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using EduCore.Data;
using EduCore.Models;
using EduCore.ViewModels;
using EduCore.Repository;
using System.ComponentModel.Design;

namespace EduCore.Services
{
    public class InstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public List<Instructor>? GetAll()
        {
            if (_instructorRepository.Exist())
                return _instructorRepository.GetAll();
            else return null;
        }
        public Instructor? GetById(int id)
        {
            return _instructorRepository.GetById(id);
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

            _instructorRepository.Add(instructor);
            _instructorRepository.Save();
        }


        public void Update(Instructor ins)
        {
            _instructorRepository.Update(ins);
        }
        public void Delete(int id)
        {
            _instructorRepository.Delete(id);
        }
        public bool Exist(int id)
        {
           return  _instructorRepository.Exist(id);
        }
        public bool Exist()
        {
            return _instructorRepository.Exist();
        }
        public List<SearchDataViewModel> SearchByName(string Name)
        {
            Name = Name.Replace(" ", "").ToLower();

            return _instructorRepository.GetInstructorsByName(Name);
            
        }
        public void Save()
        {
            _instructorRepository.Save();
        }
    }
}
