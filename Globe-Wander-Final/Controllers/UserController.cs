using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.Services;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO dataDTO)
        {
            var existingUser= await _userManager.FindByEmailAsync(dataDTO.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(dataDTO.Email), "Email is already in use.");
                return View();
            }
            var result = await userService.Register(dataDTO,this.ModelState);
            if (result!=null)
            {
                return Redirect("/");
             }
            return null;
        }



        public IActionResult Register()
        {
            return View();
        }

       

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Login");
        }
    }
}
