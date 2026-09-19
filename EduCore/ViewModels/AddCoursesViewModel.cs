using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Controllers;
using MVCFinalProject.Models;
using MVCFinalProject.Models.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.ViewModels
{
    public class AddCoursesViewModel
    {
        // [DataType(DataType.Text)]

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [Unique(ErrorMessage = "Course Name should be unique")]
        public string Name { get; set; }
        [Required]
        [Range(50, 100)]
        public int Degree { get; set; }
        [Required]
        [Range(20, 50)]
        [Remote(controller:"Course" , action: "ValidateDegree", AdditionalFields = "Degree" , ErrorMessage = "Minimum Degree should be less than Full Degree")]
        public int minDegree { get; set; }
        [Required]
        [Range(5,120 , ErrorMessage ="Course should be between 5 to 120 hour")]
        public int Hourse { get; set; }

        [Display(Name ="Department")]
        public int DeptId { get; set; }

        public List<Department>? departments { get; set; }
    }
}
