using Microsoft.EntityFrameworkCore;
using EduCore.Data;
using EduCore.Models;
using EduCore.ViewModels;
using EduCore.Repository;

namespace EduCore.Services
{
    public class TraineeService
    {
        private readonly ITraineeRepository _traineeRepository;
        public TraineeService(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
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
