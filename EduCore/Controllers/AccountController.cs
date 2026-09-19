using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.ViewModels;
using System.Security.Claims;
namespace MVCFinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController
            (UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManger)
        {
            _userManager = userManager;
            _signInManager = signInManger;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDataViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new();
                appUser.UserName = ViewModel.UserName;
                appUser.Email = ViewModel.Email;
                var result = await _userManager.CreateAsync(appUser, ViewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View("Register");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View("RegisterAdmin");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDataViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = userViewModel.UserName;
                appUser.Email = userViewModel.Email;
                var res = await _userManager.CreateAsync(appUser, userViewModel.Password);
                if (res.Succeeded) { 
                var result = await _userManager.AddToRoleAsync(appUser, "Admin");
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Add", "Role");
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
            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
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
            return View("Login");
        }

    }
}
