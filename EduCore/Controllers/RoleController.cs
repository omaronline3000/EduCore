using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class RoleController : Controller
    {
        
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddRoleViewModel roleViewModel)
        {
            IdentityRole role = new();
            role.Name = roleViewModel.Name;
           var result =  await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Add");
            }
            return View(role);
        }
    }
}
