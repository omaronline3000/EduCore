using System.ComponentModel.DataAnnotations;

namespace EduCore.ViewModels
{
    public class AssignInstructorViewModel
    {
        [Required(ErrorMessage ="*")]
        public int InstructorId { get; set; }
        [Required(ErrorMessage = "*")]
        public int CourseId { get; set; }


    }
}
