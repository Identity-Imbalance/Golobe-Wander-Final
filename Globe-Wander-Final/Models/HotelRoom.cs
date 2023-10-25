using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Globe_Wander_Final.Models
{
    public class HotelRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomNumber { get; set; }

        public int HotelID { get; set; }

        public int RoomID { get; set; }
        public virtual ICollection<Image> HotelRoomImages { get; set; }
        public string Description { get; set; }
        public int SquareFeet { get; set; }
        public int Bathrooms { get; set; }
        public int  Beds { get; set; }
        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }

        [ForeignKey("HotelID")]
        public Hotel? Hotel { get; set; }

        [ForeignKey("RoomID")]
        public Room? Rooms { get; set; }

        public BookingRoom? BookingRoom { get; set; }
    }
}
