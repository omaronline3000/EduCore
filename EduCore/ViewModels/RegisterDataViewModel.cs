using System.ComponentModel.DataAnnotations;

namespace EduCore.ViewModels
{
    public class RegisterDataViewModel
    {

       // [Required(ErrorMessage = "*")]
        [Display(Name = "User Id (For Trainees and Instructors)")]
        public int? id { get; set; }
        public string UserName { get; set; }

        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Confirmed Password")]
        public string ConfirmedPassowrd {  get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }


        public List<RegisterRoleDataViewModel>? Roles { get; set; } 

    }
}
