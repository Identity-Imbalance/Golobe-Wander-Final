namespace Globe_Wander_Final.Models.DTOs
{
    public class NewBookingRoomDTO
    {
        public int HotelID { get; set; }

        public int RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
