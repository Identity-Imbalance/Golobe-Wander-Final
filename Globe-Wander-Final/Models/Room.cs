using System.ComponentModel.DataAnnotations;

namespace Globe_Wander_Final.Models
{

    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
        public Layout Layout { get; set; }
        public List<HotelRoom>? HotelRooms { get; set; }
    }
    public enum Layout
    {
        [Display(Name = "Studio")]
        Studio = 1,
        [Display(Name = "OneBed")]
        OneBed,
        [Display(Name = "TwoBed")]
        TwoBed
    }
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Room> RoomAmenities { get; set; }
    }

    public class RoomAmenity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }

}
