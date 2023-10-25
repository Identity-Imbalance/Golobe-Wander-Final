using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
                var newUser = await userService.UpdateProfile(model, User.Identity.Name, image);
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

        // TODO: Valiadation the error mesage
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(LogInDTO data)
        {
            var user = await userService.Authenticate(data.UserName, data.Password, this.ModelState);
            if (user != null)
            {
                if (user.Roles[0] != "User" && user.Roles[0] != null)
                {
                    return Redirect("/Dashboard");
                }
                return Redirect("/");
            }
            ModelState.AddModelError(nameof(data.Password), "Password is wrong or username not exist");
            return View(user);
        }

        // TODO: Validation for the inputs -- Abdallah
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
               var loginInUser =  await userService.Authenticate(dataDTO.UserName, dataDTO.Password, this.ModelState);
                if(loginInUser.Roles[0] != "User" && loginInUser.Roles[0] != null)
                {
                    return Redirect("/Dashboard");
                }
                    return Redirect("/");
            }
            return View(dataDTO);
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
