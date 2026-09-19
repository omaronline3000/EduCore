namespace EduCore.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly APPDbContext _context;
        public DepartmentRepository(APPDbContext context)
        {
            _context = context;
        }

        public void Add(Department dep)
        {

            _context.departments.Add(dep);
        }

        public List<Department>? GetAll()
        {
            return _context.departments.ToList();
        }
        public Department? GetById(int id)
        {
            return _context.departments.Find(id);
        }

        public void Update(Department dep)
        {
            _context.departments.Update(dep);
        }
        public void Delete(int id)
        {
            var department = _context.departments.Find(id);
            if (department is not null) department.IsDeleted = true;
        }


        public bool Exist(int id)
        {
            return _context.departments.Any(c => c.Id == id);
        }
        public bool Exist()
        {
            return _context.departments.Any();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
