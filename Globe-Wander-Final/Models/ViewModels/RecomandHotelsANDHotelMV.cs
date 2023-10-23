using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models
{
   
        public class RecomandHotelsANDHotelMV
    {
        public  HotelDTO hotel { get; set; }
        public List<HotelDTO>? recomandedHotels { get; set; }
    }
}
