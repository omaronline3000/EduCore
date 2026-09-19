using MVCFinalProject.Models;

namespace MVCFinalProject.ViewModels
{
    public class AddingInstructorViewModel
    {
        // Add View , Get Request
        public string Name { get; set; }
        public int salary { get; set; }
        public string Address { get; set; }

        public int DepartmentId { get; set; }
        public int CourseId { get; set; }

        // Add View , Post Request
        public List<Department>? departments { get; set; } 
        public List<Course>? courses { get; set; }


    }
}
