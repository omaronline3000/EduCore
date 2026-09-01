using MVCFinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.ViewModels
{
    public class AddCoursesViewModel
    {
       // [DataType(DataType.Text)]
        public string Name { get; set; }
        public int Degree { get; set; }
        public int minDegree { get; set; }
        public int Hourse { get; set; }
        [Display(Name ="Department")]
        public int DeptId { get; set; }

        public List<Department> departments { get; set; }
    }
}
