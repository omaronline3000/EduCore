namespace MVCFinalProject.Repository
{
    public interface IInstructorRepository
    {
        // CRUD
        void Add(Instructor ins);

        List<Instructor>? GetAll();
        Instructor? GetById(int id);

        void Update(Instructor ins);
        void Delete(int id);
        void Save();
    }
}
