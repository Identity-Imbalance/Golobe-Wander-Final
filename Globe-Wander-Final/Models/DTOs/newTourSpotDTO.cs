using System.ComponentModel.DataAnnotations;

namespace Globe_Wander_Final.Models.DTOs
{
    public class newTourSpotDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The City field is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The PhoneNumber field is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public Category Category { get; set; }
    }
}
