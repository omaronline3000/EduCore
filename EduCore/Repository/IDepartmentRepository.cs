namespace EduCore.Repository
{
    public interface IDepartmentRepository
    {
        // CRUD
        void Add(Department dep);

        List<Department>? GetAll();
        Department? GetById(int id);

        void Update(Department dep);
        void Delete(int id);
        void Save();

        public bool Exist(int id);
        public bool Exist();
    }
}
