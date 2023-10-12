using System.ComponentModel.DataAnnotations;

namespace Globe_Wander_Final.Models.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public IList<string> Roles { get; set; }
    }
}
