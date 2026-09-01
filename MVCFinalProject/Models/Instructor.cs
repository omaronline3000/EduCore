using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }

        public bool IsDeleted { get; set; }

        public int deptId { get; set; }
        public int crsId { get; set; }

        public Department department { get; set; }
        public Course course { get; set; }
    }
}
