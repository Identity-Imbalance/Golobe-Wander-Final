namespace Globe_Wander_Final.Models.DTOs
{
    public class BookingTripDTO
    {
        public int ID { get; set; }

        public int TripID { get; set; }

        public int NumberOfPersons { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public decimal CostPerPerson { get; set; }

        public int Duration { get; set; }

        public decimal TotalPrice { get; set; }

        public string Username { get; set; }
    }
}
