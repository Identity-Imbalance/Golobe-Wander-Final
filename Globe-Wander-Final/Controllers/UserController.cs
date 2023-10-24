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

        public async Task<IActionResult> Profile()
        {
            var user = await userService.GetUser(User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserUpdateDTO model, IFormFile? image)
        {
            if (_signInManager.IsSignedIn(User) && ModelState.IsValid)
            {
                var newUser = await userService.UpdateProfile(model, User.Identity.Name,User);
                if (newUser != null)
                {
                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    return View(model);
                }

            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            var result = await userService.ChangePassword(currentPassword, newPassword, confirmPassword, User.Identity.Name);
            if (result)
            {
                return RedirectToAction("Profile", "User");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to change the password.");
                return RedirectToAction("Profile", "User");
            }

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<ActionResult<UserDTO>> Login(LogInDTO data)

        {
            if (ModelState.IsValid)
            {
                var user = await userService.Authenticate(data.UserName, data.Password);


                if (user == null)
                {
                    this.ModelState.AddModelError(String.Empty, "Invalid Login");
                    return View(data);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO dataDTO)
        {
            dataDTO.Roles[0] = "User";
            var existingUser = await _userManager.FindByEmailAsync(dataDTO.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(dataDTO.Email), "Email is already in use.");
                return View();
            }
            var result = await userService.Register(dataDTO, this.ModelState, User);

            if (result != null)
            {
                await userService.Authenticate(dataDTO.UserName, dataDTO.Password);
                return RedirectToAction("/");
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
