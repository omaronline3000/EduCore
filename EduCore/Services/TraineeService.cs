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


        public void AddTrainee(Trainee tra)
        {

            _traineeRepository.Add(tra);
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
        }
        public void DeleteTrainee(int id)
        {
            _traineeRepository.Delete(id);
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
