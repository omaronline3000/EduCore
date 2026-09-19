using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.ViewModels
{
    public class RegisterDataViewModel
    {
        
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
        public string? Role { get; set; }

    }
}
