﻿namespace Globe_Wander_Final.Models.DTOs
{
    public class HotelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TourSpotID { get; set; }

        public List<HotelRoomDTO>? HotelRoom { get; set; }
    }
}
