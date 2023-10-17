namespace Globe_Wander_Final.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }

        public int StarRate { get; set; }
        public string Description { get; set; }

        public ICollection<HotelFacility> HotelFacilities { get; set; }
        public int TourSpotID { get; set; }

        public TourSpot? TourSpot { get; set; }

        public List<HotelRoom>? HotelRoom { get; set; }
    }

    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Hotel> HotelFacilities { get; set; }
    }

    public class HotelFacility
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }

}





