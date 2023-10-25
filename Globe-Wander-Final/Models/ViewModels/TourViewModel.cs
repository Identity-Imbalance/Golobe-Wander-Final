using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.ViewModels
{
    public class TourViewModel
    {
        public List<TourSpotDTO> TourSpots { get; set; }
        public List<TripDTO>? Trips { get; set; }
        public List<HotelDTO>? recomandedHotels { get; set; }
        public virtual ICollection<Image> TripAndHotelRoomImages { get; set; }
        public List<HotelRoomDTO>? HotelRoomImages { get;set; }

    }
}
