using System.ComponentModel.DataAnnotations;

namespace Globe_Wander_Final.Models
{
    public class TourSpot
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Img { get; set; }
        public string City { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public string PhoneNumber { get; set; }

        public List<Hotel>? Hotels { get; set; }

        public List<Trip>? Trips { get; set; }
    }


    public enum Category
    {
        [Display(Name = "Ritual")]
        Ritual = 1,
        [Display(Name = "Medical")]
        Medical = 2,
        [Display(Name = "Historical")]
        Historical = 3,
        [Display(Name = "Natural")]
        Natural = 4
    }
}
