using EduCore.DTO;

namespace EduCore.Repository
{
    public interface ICourseRepository
    {
        // Main CRUD operations 
        public void Add(Course crs);

        public List<Course> GetAll();
        public List<Course> GetPage(int pageNumber , int pageSize);
        public Course GetById(int id);

        public void Update(Course crs);
        public void Delete(int id);
        public void Save();

        // Main Features
        public bool Exist(int id);
        public bool Exist();
        public DisplayCourseWithItsTraineeResults GetCourseWithTraineeResults(Course course);

        public List<CoursesDataByDepartmetnDTO> GetCoursesByDeptId(int deptId);
    }
}
