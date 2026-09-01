using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Degree { get; set; }
        public int minDegree { get; set; }
        public int Hourse { get; set; }

        public bool IsDeleted { get; set; }
        public int deptId { get; set; }

        public Department department {get; set;}

        public ICollection<Instructor> instructors { get; set; }

        public ICollection<CrsResult> crsResults { get; set; }

    }
}
