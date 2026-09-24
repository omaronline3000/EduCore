using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using EduCore.Data;
using EduCore.Models;
using EduCore.ViewModels;
using EduCore.Repository;
using System.ComponentModel.Design;
using System.Security.Cryptography.Pkcs;
using System.Security.Claims;

namespace EduCore.Services
{
    public class InstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public InstructorInfoViewModel GetInfo(ClaimsPrincipal User)
        {
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            int? id = _instructorRepository.GetByUserId(userid)?.Id;
            string? name = User.Identity.Name;
            string? address = User.FindFirstValue("Address");
            string? email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Course? course = _instructorRepository.GetByUserId(userid)?.course;
            string? dep = _instructorRepository.GetByUserId(userid)?.department?.Name;
            var info = new InstructorInfoViewModel()
            {
                id = id,
                Userid = userid,
                Name = name,
                Address = address,
                Email = email,
                Course = course,
                Department = dep
            };
            return info;
        }

        public List<Instructor>? GetAll()
        {
                return _instructorRepository.GetAll();
        }
        public Instructor? GetById(int id)
        {
            return _instructorRepository.GetById(id);
        }

        public Instructor? GetByUserId(string id)
        {
            return _instructorRepository.GetByUserId(id);
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
            _instructorRepository.Save();
        }
        public void Delete(int id)
        {
            _instructorRepository.Delete(id);
            _instructorRepository.Save();
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
