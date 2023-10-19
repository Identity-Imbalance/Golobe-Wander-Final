using Globe_Wander_Final.Migrations;
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
        private UserManager<ApplicationUser> _userManager;
        private IUser _UserService;
        public UserController(UserManager<ApplicationUser>manager, IUser UserService)
        {
            _userManager = manager;
            _UserService = UserService;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO dataDTO)
        {
            var existingUser= await _userManager.FindByEmailAsync(dataDTO.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(dataDTO.Email), "Email is already in use.");
                return View();
            }
            var result = await _UserService.Register(dataDTO,this.ModelState);
            if (result!=null)
            {
                return Redirect("/");
             }
            return null;
        }


        public IActionResult Profile()
        {
            return View();
        }


    }
}
