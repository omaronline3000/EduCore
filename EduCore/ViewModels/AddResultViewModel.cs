using System.ComponentModel.DataAnnotations;

namespace EduCore.ViewModels
{
    public class AddResultViewModel
    {
        [Required(ErrorMessage = "*")]
        [Range(1, 100)]
        public int Degree { get; set; }
        [Required(ErrorMessage = "*")]
        public int traineeId { get; set; }
        [Required(ErrorMessage = "*")]
        public int crsId { get; set; }
    }
}
