namespace Globe_Wander_Final.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }


        public int? RoomNumber { get; set; }
        public virtual HotelRoom? HotelRoom { get; set; }

        public int? HotelId { get; set; }
        public virtual Hotel? Hotel { get; set; }
        public int? TripId { get; set; }
        public virtual Trip? Trip { get; set; }



    }
}
