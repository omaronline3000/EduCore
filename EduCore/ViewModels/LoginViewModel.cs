using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me !!")]
        public bool RemeberMe { get; set; }
    }
}
