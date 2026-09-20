using System.ComponentModel.DataAnnotations;

namespace EduCore.ViewModels
{
    public class AddResultViewModel
    {
        [Required]
        [Range(1, 100)]
        public int Degree { get; set; }
        public int traineeId { get; set; }
        public int crsId { get; set; }
    }
}
