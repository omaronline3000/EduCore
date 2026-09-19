using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string managerName { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Instructor> instructors { get; set; }
        public ICollection<Course> courses { get; set; }
        public ICollection<Trainee> trainees { get; set; }

    }
}
