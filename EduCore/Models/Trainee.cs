using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public string? Address { get; set; }
        public double Grade { get; set; }

        public bool IsDeleted { get; set; }

        public int deptID { get; set; }

        public Department department { get; set; }

        public ICollection<CrsResult> crsResults { get; set; }

    }
}
