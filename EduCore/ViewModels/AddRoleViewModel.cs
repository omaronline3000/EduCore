using System.ComponentModel.DataAnnotations;

namespace EduCore.ViewModels
{
    public class AddRoleViewModel
    {
        [Display(Name ="Role Name")]
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
    }
}
