﻿namespace Globe_Wander_Final.Models.DTOs
{
    public class NewTripDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string Activity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Capacity { get; set; }

        public int Count { get; set; }

        public int TourSpotID { get; set; }
    }
}
