namespace Globe_Wander_Final.Models.DTOs
{
    public class TrendTourSpotDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public string PhoneNumber { get; set; }

        public List<TrendHotelDTO>? Hotels { get; set; }

        public List<TrendTripDTO>? Trips { get; set; }
    }
}
