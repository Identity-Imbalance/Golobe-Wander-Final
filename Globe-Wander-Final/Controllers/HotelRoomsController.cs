using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly IHotelRoom _hotelRoom;
        private readonly IHotel _hotels;
        public HotelRoomsController(IHotelRoom hotelRoom, IHotel hotels)
        {
            _hotelRoom = hotelRoom;
            _hotels = hotels;
        }
        public async Task<IActionResult> SingleRoom(int Id,int RoomNumber)
        {
            var hotel = await _hotels.GetHotelId(Id);
            var HotelRoom = await  _hotelRoom.GetHotelRoomId(Id,RoomNumber);
            var hotelandhotelroom = new HotelAndHotelRoom()
            {
                hotel = hotel,
                HotelRoomDTO = HotelRoom,
            };
            return View(hotelandhotelroom);
        }
    }
}
