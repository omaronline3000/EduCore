using System.ComponentModel.DataAnnotations;

namespace MVCFinalProject.ViewModels
{
    public class AddRoleViewModel
    {
        [Display(Name ="Role Name")]
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
    }
}
