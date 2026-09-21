using System.ComponentModel.DataAnnotations;

namespace EduCore.ViewModels
{
    public class AddingTraineeViewModel
    {
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "GPA")]
        public double Grade { get; set; }
        [Required(ErrorMessage = "*")]
        public int depId { get; set; }

        public List<Department>? Departments { get; set; }
    }
}
