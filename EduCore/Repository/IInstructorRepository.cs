namespace EduCore.Repository
{
    public interface IInstructorRepository
    {
        // CRUD
        void Add(Instructor ins);
        List<Instructor>? GetAll();
        Instructor? GetById(int id);
        Instructor? GetByUserId(string id);
        void Update(Instructor ins);
        void Delete(int id);
        void Save();
        public bool Exist(int id);
        public bool Exist();

        // Main Features
        
        List<SearchDataViewModel> GetInstructorsByName(string name);

    }
}
