using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class BookingRoomsController : Controller
    {
        private readonly IHotelRoom _hotelRoom;
        private readonly IBookingRoom _bookingRoom;
        private readonly IHotel _hotel;

        public BookingRoomsController(IHotelRoom hotelRoom , IBookingRoom bookingRoom, IHotel hotel)
        {
            _hotelRoom = hotelRoom;
            _bookingRoom = bookingRoom;
            _hotel = hotel;
       
      
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookingHistory()
        {
            return View();
        }

        [Authorize]
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
           var user = User.Identity.Name;
            await _bookingRoom.CreateBookingRoom(hotelRoomAndBookingForm.NewBookingRoomDTO, user);
            var Form = new HotelRoomandBooking
            {
                HotelRoomDTO = hotelRoom,
            };

            return View(Form);
        }

        public async Task<IActionResult> MyBookings()
        {
            var user = User.Identity.Name;

            var hotelRoomsData = await _hotelRoom.GetHotelRooms();

            var hotelsData = await _hotel.GetAllHotels();
            var BookingData = await _bookingRoom.GetAllBookingRoomsForUser(User.Identity.Name);
            var userbooking = new MyBookingsDTO
            {
                HotelRoomDTO = hotelRoomsData,
                HotelDTOs= hotelsData,
                BookingRoomDTO= BookingData

            };



            return View(userbooking);
        }

        public async Task<IActionResult> UserDeleteBooking(int Id)
        {
          
           await _bookingRoom.DeleteBookingRoom(Id);
          


            return RedirectToAction("MyBookings");
        }



    }
}
