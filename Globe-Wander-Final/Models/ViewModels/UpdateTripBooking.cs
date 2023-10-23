using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.ViewModels
{
    public class UpdateTripBooking
    {
        public UpdateBookingTripDTO? updateBooking { get; set; }
        public BookingTripDTO? bookingTripDTO { get; set; }
    }
}