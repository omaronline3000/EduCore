namespace MVCFinalProject.Repository
{
    public interface ITraineeRepository
    {
        // CRUD
        void Add(Trainee tra);

        List<Trainee>? GetAll();
        Trainee? GetById(int id);

        void Update(Trainee tra);
        void Delete(Trainee tra);
        void Save();
    }
}
