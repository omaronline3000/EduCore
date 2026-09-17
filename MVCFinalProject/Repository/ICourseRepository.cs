namespace MVCFinalProject.Repository
{
    public interface ICourseRepository
    {
        // CRUD
        public void Add(Course crs);

        public List<Course>? GetAll();
        public Course? GetById(int id);

        public void Update(Course crs);
        public void Delete(int id);
        public void Save();
    }
}
