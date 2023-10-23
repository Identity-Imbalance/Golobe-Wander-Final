using System.ComponentModel.DataAnnotations;

namespace Globe_Wander_Final.Models.DTOs
{
    public class UserUpdateDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string? ImageUrl { get; set; }
    }
}
