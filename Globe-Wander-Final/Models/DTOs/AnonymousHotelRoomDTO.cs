﻿namespace Globe_Wander_Final.Models.DTOs
{
    public class AnonymousHotelRoomDTO
    {
        public int RoomNumber { get; set; }

        public int HotelID { get; set; }

        public int RoomID { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }
    }
}
