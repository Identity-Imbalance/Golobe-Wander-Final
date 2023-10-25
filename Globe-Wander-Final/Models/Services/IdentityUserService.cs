using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Globe_Wander_Final.Models.Services
{
    /// <summary>
    /// Service implementation for user authentication and registration.
    /// </summary>
    public class IdentityUserService : IUser
    {
        private readonly UserManager<ApplicationUser> _UserManager;

        private SignInManager<ApplicationUser> _signInManager;

        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly IAddImage _upload;

        public IdentityUserService(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> sim, IAddImage upload, IHttpContextAccessor httpContextAccessor)
        {
            _UserManager = manager;
            _signInManager = sim;
            _upload = upload;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// Authenticate a user based on username and password.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Password of the user.</param>
        public async Task<UserDTO> Authenticate(string username, string password, ModelStateDictionary modelState)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);


            if (result.Succeeded)
            {
                var user = await _UserManager.FindByNameAsync(username);
                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = await _UserManager.GetRolesAsync(user)
                };
            }
            modelState.AddModelError(string.Empty, "Username or password wrong");
            return null;
            

        }

        /// <summary>
        /// Get user information based on the ClaimsPrincipal.
        /// </summary>
        /// <param name="principal">ClaimsPrincipal representing the user.</param>
        public async Task<UserUpdateDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await _UserManager.GetUserAsync(principal);
            if (user != null)
            {
                return new UserUpdateDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    ImageUrl = user.ImageUrl
                };
            }
            return null;

        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _UserManager.FindByIdAsync(userId);
        }


        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="registerUserDto">Registration information for the user.</param>
        /// <param name="modelState">ModelStateDictionary to store validation errors.</param>
        public async Task<UserDTO> Register(RegisterUserDTO registerUserDto, ModelStateDictionary modelState, ClaimsPrincipal User)
        {
            if (!modelState.IsValid)
            {
                return null;
            }
            var newUser = new ApplicationUser
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                PhoneNumber = registerUserDto.PhoneNumber,
            };
            var result = await _UserManager.CreateAsync(newUser, registerUserDto.Password);
            if (result.Succeeded)
            {
                await _UserManager.AddToRolesAsync(newUser, registerUserDto.Roles);
                return new UserDTO
                {
                    Id = newUser.Id,
                    UserName = newUser.UserName,
                    Roles = await _UserManager.GetRolesAsync(newUser)
                };

            }
            var exisitngUser = await _UserManager.FindByEmailAsync(registerUserDto.Email);
            if (exisitngUser != null)
            {
                modelState.AddModelError(nameof(registerUserDto.Email), "Email Is Already Exisit!!");
                return null;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(registerUserDto.Password) :
                    error.Code.Contains("Email") ? nameof(registerUserDto.Email) :
                    error.Code.Contains("UserName") ? nameof(registerUserDto.UserName) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
            //bool IsAdminManager = User.IsInRole("Admin Manager");

            //if (IsAdminManager || registerUserDto.Roles.Contains("User"))
            //{
            //    var user = new ApplicationUser()
            //    {
            //        UserName = registerUserDto.UserName,
            //        Email = registerUserDto.Email,
            //        PhoneNumber = registerUserDto.PhoneNumber,
            //    };
            //    var result = await _UserManager.CreateAsync(user, registerUserDto.Password);
            //    if (result.Succeeded)
            //    {
            //        await _UserManager.AddToRolesAsync(user, registerUserDto.Roles);
            //        return new UserDTO
            //        {
            //            Id = user.Id,
            //            UserName = user.UserName,
            //            //Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(100)),
            //            Roles = await _UserManager.GetRolesAsync(user)

            //        };
            //    }
            //    else
            //    {
            //        foreach (var error in result.Errors)
            //        {
            //            var errorMessage = error.Code.Contains("Password") ? nameof(registerUserDto.Password) :
            //                               error.Code.Contains("Email") ? nameof(registerUserDto.Email) :
            //                               error.Code.Contains("Username") ? nameof(registerUserDto.UserName) :
            //                               //  error.Code.Contains("Phone") ? nameof(registerUserDto.Phone) :
            //                               "";
            //            modelState.AddModelError(errorMessage, error.Description);

            //        };
            //        return null;
            //    }

            //}
            //else
            //{
            //    modelState.AddModelError("", "You don't have permission to create this type of account.");
            //    return null;
            //}

        }

        public async Task<ApplicationUser> UpdateProfile(UserUpdateDTO updateDTO, string Username, IFormFile file)
        {
            var existUser = await _UserManager.FindByNameAsync(Username);

            if (existUser != null)
            {
                existUser.UserName = updateDTO.UserName;
                existUser.Email = updateDTO.Email;
                existUser.PhoneNumber = updateDTO.PhoneNumber;

                if (file != null)
                {
                    await _upload.UpdateProfileImage(file, updateDTO);
                    existUser.ImageUrl = updateDTO.ImageUrl;
                }

                await _UserManager.UpdateAsync(existUser);

                // Clear the user's session data and re-authenticate
                await _signInManager.RefreshSignInAsync(existUser);


                return existUser;
            }

            return null;
        }

        public async Task<bool> ChangePassword(string currentPassword, string newPassword, string confirmPassword, string userName)
        {
            var existUser = await _UserManager.FindByNameAsync(userName);

            if (existUser != null)
            {
                if (newPassword != confirmPassword)
                {
                    return false;
                }

                var isCorrect = await _UserManager.ChangePasswordAsync(existUser, currentPassword, newPassword);

                if (isCorrect.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(existUser);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}