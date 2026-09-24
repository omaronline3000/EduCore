using Microsoft.EntityFrameworkCore;
using EduCore.Data;
using EduCore.Models;
using EduCore.ViewModels;
using EduCore.Repository;
using System.Security.Claims;

namespace EduCore.Services
{
    public class TraineeService
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly InstructorService _instructorService;
        public TraineeService(ITraineeRepository traineeRepository , InstructorService instructorService)
        {
            _traineeRepository = traineeRepository;
            _instructorService = instructorService;
        }


        public void AddTrainee(AddingTraineeViewModel viewModel)
        {
            Trainee trainee = new()
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                ImageURL = viewModel.ImageURL,
                deptID = viewModel.depId,
                Grade = viewModel.Grade,
            };

            _traineeRepository.Add(trainee);
            _traineeRepository.Save();
        }

        public List<Trainee>? GetAll()
        {
            return _traineeRepository.GetAll();
        }
        public Trainee? GetById(int id)
        {
            return _traineeRepository.GetById(id);
        }

        public List<Trainee>? GetByInstructorId(int id)
        {
            var course = _instructorService.GetById(id)?.course;
            return _traineeRepository.GetByCourseId(course.Id);
        }
        
        public Trainee? GetByUserId(string id)
        {
            return _traineeRepository.GetByUserId(id);
        }

        public TraineeInfoViewModel GetInfo(ClaimsPrincipal User)
        {
            return new TraineeInfoViewModel()
            {
                id = _traineeRepository.GetByUserId(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value)?.Id,
                Userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Name = User.Identity.Name,
                Address = User.FindFirstValue("Address"),
                Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                Department = _traineeRepository.GetByUserId(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value)?.department.Name,
                Grade = Convert.ToString(_traineeRepository.GetByUserId(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value)?.Grade)
            };
        }

        public void UpdateTrainee(Trainee tar)
        {
            _traineeRepository.Update(tar);
            _traineeRepository.Save();
        }
        public void DeleteTrainee(int id)
        {
            _traineeRepository.Delete(id);
            _traineeRepository.Save();
        }


        public bool Exist(int id)
        {
            return _traineeRepository.Exist(id);
        }

        public bool Exist()
        {
            return _traineeRepository.Exist();
        }
        public void Save()
        {
            _traineeRepository.Save();
        }
    }
}
