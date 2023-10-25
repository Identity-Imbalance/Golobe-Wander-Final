using System.ComponentModel.DataAnnotations;

namespace Globe_Wander_Final.Models.DTOs
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number")]
        public string PhoneNumber { get; set; }

        public IList<string> Roles { get; set; }
    }
}
