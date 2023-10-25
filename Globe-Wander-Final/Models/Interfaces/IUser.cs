using Globe_Wander_Final.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerUser, ModelStateDictionary modelState, ClaimsPrincipal User);

        public Task<UserDTO> Authenticate(string username, string password, ModelStateDictionary modelState);

        public Task<UserUpdateDTO> GetUser(ClaimsPrincipal principal);

        public Task<ApplicationUser> GetUserByIdAsync(string userId);

        public Task<ApplicationUser> UpdateProfile(UserUpdateDTO updateDTO, string userName, IFormFile file);

        public Task<bool> ChangePassword(string currentPassword, string newPassword, string confirmPassword, string userName);
    }
}
