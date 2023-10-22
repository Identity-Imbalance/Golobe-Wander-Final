using Globe_Wander_Final.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerUser, ModelStateDictionary modelState,ClaimsPrincipal User);

        public Task<UserDTO> Authenticate(string username, string password);

        public Task<UserDTO> GetUser(ClaimsPrincipal principal);

        public Task<ApplicationUser> GetUserByIdAsync(string userId);

        public Task<UserDTO> UpdateProfile(UserUpdateDTO updateDTO, ClaimsPrincipal claimsPrincipal);
    }
}
