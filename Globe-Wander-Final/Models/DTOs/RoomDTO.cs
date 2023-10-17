namespace Globe_Wander_Final.Models.DTOs
{
    public class RoomDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
        public Layout Layout { get; set; }
    }
}
