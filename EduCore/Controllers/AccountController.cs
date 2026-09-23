using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EduCore.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
namespace EduCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController
            (UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManger,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManger;
            _roleManager = roleManager;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Register()
        {
            RegisterDataViewModel model = new RegisterDataViewModel()
            {
                Roles = _roleManager.Roles.
                Select(r => 
                new RegisterRoleDataViewModel(){ 
                    Id =  r.Id , 
                    Name =  r.Name})
                .ToList()
            };
            return View("Register" , model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterDataViewModel userViewModel)
        {
            if(userViewModel.Role.IsNullOrEmpty())
            {
                ModelState.AddModelError("", "Please Choose Role");
            }
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = userViewModel.UserName;
                appUser.Email = userViewModel.Email;
                var res = await _userManager.CreateAsync(appUser, userViewModel.Password);
                if (res.Succeeded) { 
                var result = await _userManager.AddToRoleAsync(appUser, userViewModel.Role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Register");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
                else
                {
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            userViewModel.Roles = _roleManager.Roles.
                Select(r =>
                new RegisterRoleDataViewModel()
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToList();
            return View(userViewModel);
        }


        [HttpGet]
        public IActionResult Login()
        {
           if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("DashBoard", User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userViewModel)
        {
            
            if (ModelState.IsValid)
            {
                List<Claim> Claims = new List<Claim>();
                ApplicationUser? appUser =
                      await _userManager.FindByNameAsync(userViewModel.UserName);
                if (appUser is not null)
                {
                    bool valid =
                        await _userManager.CheckPasswordAsync(appUser, userViewModel.Password);
                    if (valid)
                    {
                        string adderss = appUser.Address;
                        if (adderss is not null)
                            Claims.Add(new Claim("Address", appUser.Address));
                        //await _signInManager.SignInAsync()
                        await _signInManager.SignInWithClaimsAsync(appUser, userViewModel.RemeberMe, Claims);
                        return RedirectToAction("Index", "Course");
                    }
                }
            }
            ModelState.AddModelError("", "UserName or Password is wrong");
            return View("Login", userViewModel);
            
        }
        // Test
        public IActionResult TestAuth(LoginViewModel userViewModel)
        {
            string? id = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (id is null) return Content("Guest Account");
            else return Content($"{id} Account");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
