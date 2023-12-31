﻿namespace Globe_Wander_Final.Models.DTOs
{
    public class TrendHotelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TrendHotelRoomDTO>? HotelRoom { get; set; }
    }
}
