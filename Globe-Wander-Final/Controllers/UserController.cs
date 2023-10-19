using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class UserController : Controller
    {
        private IUser userService;
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public UserController(IUser service, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            userService = service;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInDTO data)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.Authenticate(data.UserName, data.Password);

                if (user != null)
                {                    
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(data);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDTO data)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.Register(data, this.ModelState, User);

                if (user != null)
                {                    
                    return RedirectToAction("Index", "Home"); 
                }
            }            
            return View(data);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Login");
        }
    }
}
