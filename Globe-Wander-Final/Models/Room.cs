using System.ComponentModel.DataAnnotations;

namespace Globe_Wander_Final.Models
{
  
        public class Room
        {
            public int ID { get; set; }

            public string Name { get; set; }

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
  
}
