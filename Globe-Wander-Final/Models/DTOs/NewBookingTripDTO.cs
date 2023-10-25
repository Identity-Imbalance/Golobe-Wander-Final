namespace Globe_Wander_Final.Models.DTOs
{
    public class NewBookingTripDTO
    {
        public int TripID { get; set; }

        public int NumberOfPersons { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
