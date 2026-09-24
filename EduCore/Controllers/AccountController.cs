using EduCore.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
namespace EduCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly InstructorService _instructorService;
        private readonly TraineeService _traineeService;
        public AccountController
            (UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManger,
            RoleManager<IdentityRole> roleManager ,
            InstructorService instructorService , 
            TraineeService traineeService)
        {
            _userManager = userManager;
            _signInManager = signInManger;
            _roleManager = roleManager;
            _instructorService = instructorService;
            _traineeService = traineeService;
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterDataViewModel userViewModel)
        {
            if (userViewModel.Role.IsNullOrEmpty())
                ModelState.AddModelError("", "Please Choose Role");
            else if (userViewModel.Role != "Admin" && userViewModel.id is null)
                ModelState.AddModelError("id", "You should add the id for instructors and Trainees");
            else if (userViewModel.Role == "Instructor" && !_instructorService.Exist((int)userViewModel.id!))
                ModelState.AddModelError("id", "This Id is not for instructor");
            else if (userViewModel.Role == "Trainee" && !_traineeService.Exist((int)userViewModel.id!))
                ModelState.AddModelError("id", "This Id is not for trainee");

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

                    if(userViewModel.Role == "Instructor")
                    {
                            var instructor = _instructorService.GetById((int)userViewModel.id!);
                            instructor.UserId = appUser.Id;
                    }else if (userViewModel.Role == "Trainee")
                        {
                            var trainee = _traineeService.GetById((int)userViewModel.id!);
                            trainee.UserId = appUser.Id;
                            _traineeService.Save();
                        }

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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
           if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("DashBoard", User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
            return View("Login");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                        return RedirectToAction("DashBoard", User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);
                    }
                }
            }
            ModelState.AddModelError("", "UserName or Password is wrong");
            return View("Login", userViewModel);
            
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View("AccessDenied",ReturnUrl);
        }

    }
}
