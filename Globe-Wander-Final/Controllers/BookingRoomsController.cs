using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class BookingRoomsController : Controller
    {
        private readonly IHotelRoom _hotelRoom;
        private readonly IBookingRoom _bookingRoom;
        private SignInManager<ApplicationUser> _signInManager;

        public BookingRoomsController(IHotelRoom hotelRoom , IBookingRoom bookingRoom, SignInManager<ApplicationUser>  signInManager)
        {
            _hotelRoom = hotelRoom;
            _bookingRoom = bookingRoom;
            _signInManager = signInManager;
      
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookingHistory()
        {
            return View();
        }


        public async Task<IActionResult> BookingForm(int HotelID, int RoomNumber)
        {

            var hotelRoom = await _hotelRoom.GetHotelRoomId(HotelID, RoomNumber);
            var hotelRoomAndBookingForm = new HotelRoomandBooking
            {
                HotelRoomDTO = hotelRoom,
            };

            return View(hotelRoomAndBookingForm);
        }

        [HttpPost]
        public async Task<IActionResult> BookingForm(HotelRoomandBooking hotelRoomAndBookingForm)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoomId(hotelRoomAndBookingForm.NewBookingRoomDTO.HotelID, hotelRoomAndBookingForm.NewBookingRoomDTO.RoomNumber);

            var Form = new HotelRoomandBooking
            {
                HotelRoomDTO = hotelRoom,
            };

            return View(Form);
        }



    }
}
