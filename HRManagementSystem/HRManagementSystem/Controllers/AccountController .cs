using HRManagementSystem.DAL.Entities;
using HRManagementSystem.Web.ViewModels;
using HRManagementSystem.Web.ViewModels.HRManagementSystem.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerData)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser
                {
                    UserName = registerData.UserName,
                    Email = registerData.Email,
                };
                IdentityResult result = await _userManager.CreateAsync(applicationUser, registerData.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(applicationUser, false);

                    return RedirectToAction("Index", "Test");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View("Register", registerData);
        }


        public async Task<IActionResult> Login(LogInViewModel logInViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(logInViewModel);
            }

            ApplicationUser User = await _userManager.FindByEmailAsync(logInViewModel.Email);

            if (User == null)
            {
                ModelState.AddModelError("", "Invalid Email Or Password");
                return View(logInViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync
                    (User,
                    logInViewModel.Password,
                    logInViewModel.RememberMe == true,
                     lockoutOnFailure: true
                    );
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Test");
            }

            ModelState.AddModelError("", "Invalid Log In ");

            return View(logInViewModel);

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("LogIn");
        }


    }
}
