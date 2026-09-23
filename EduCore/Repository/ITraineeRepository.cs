namespace EduCore.Repository
{
    public interface ITraineeRepository
    {
        // CRUD
        void Add(Trainee tra);

        List<Trainee>? GetAll();
        Trainee? GetById(int id);
        Trainee? GetByUserId(string id);
        void Update(Trainee tra);
        void Delete(int id);
        void Save();

        public bool Exist(int id);
        public bool Exist();

        // Main Features

    }
}
