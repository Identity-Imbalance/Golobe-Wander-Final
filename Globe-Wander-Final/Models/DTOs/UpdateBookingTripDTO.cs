namespace Globe_Wander_Final.Models.DTOs
{
    public class UpdateBookingTripDTO
    {
        public int ID { get; set; }

        public int NumberOfPersons { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
