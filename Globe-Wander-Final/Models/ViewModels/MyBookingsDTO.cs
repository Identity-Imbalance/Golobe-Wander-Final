using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.ViewModels
{
    public class MyBookingsDTO
    {
        public List<TripDTO>? TripDTOs { get; set; }

        public List<BookingTripDTO>? BookingTripDTO { get; set; }

        public List<HotelDTO>? HotelDTOs { get; set; }

        public List<BookingRoomDTO>? BookingRoomDTO { get; set; }
        public List<HotelRoomDTO>? HotelRoomDTO { get; set; }
    }
}
