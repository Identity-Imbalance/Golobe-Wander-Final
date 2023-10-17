namespace Globe_Wander_Final.Models.DTOs
{
    public class HotelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }

        public int StarRate { get; set; }
        public string Description { get; set; }

        public ICollection<HotelFacility> HotelFacilities { get; set; }

        public int TourSpotID { get; set; }

        public List<HotelRoomDTO>? HotelRoom { get; set; }
    }
}
