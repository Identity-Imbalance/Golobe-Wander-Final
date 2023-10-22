using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.ViewModels
{
    public class UpdateBooking
    {
        public DurationBookingRoomDTO? updateBooking { get; set; }
        public BookingRoomDTO? bookingRoom { get; set; }
    }
}
