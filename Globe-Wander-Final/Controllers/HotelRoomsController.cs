using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Globe_Wander_Final.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly IHotelRoom _hotelRoom;
        private readonly IHotel _hotels;
        private readonly IRoom _room;
        private readonly IAddImage _addImage;
        public HotelRoomsController(IHotelRoom hotelRoom, IHotel hotels,IRoom room, IAddImage addImage)
        {
            _hotelRoom = hotelRoom;
            _hotels = hotels;
            _room = room;
            _addImage = addImage;
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

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        public async Task<IActionResult> CreateHotelRoom()
        {
            var hotels = await _hotels.GetAllHotels();

            var rooms = await _room.GetRooms();

            ViewBag.Hotels = hotels;
            ViewBag.Rooms = rooms;

            return View();
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateHotelRoom(HotelRoomDTOCreate hotelRoom,List<IFormFile> images)
        {
            hotelRoom.IsAvailable = true;
            if (ModelState.IsValid)
            {
                var newHotelRoom = await _hotelRoom.CreateHotelRoom(hotelRoom);

                if (images.Count > 0)
                {
                    await _addImage.UploadHotelRoomImages(images, newHotelRoom);
                }
                return RedirectToAction("CreateHotelRoom", "HotelRooms");
            }
            else
            {
                var hotels = await _hotels.GetAllHotels();

                var rooms = await _room.GetRooms();

                ViewBag.Hotels = hotels;
                ViewBag.Rooms = rooms;

                return View();
            }
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        public async Task<IActionResult> ListHotelRooms(int? page)
        {
            var pageSize = 6;

            var pageNumber = page ?? 1;

            var hotelRoomsList = await _hotelRoom.GetHotelRooms();

            var pageList = hotelRoomsList.ToPagedList(pageNumber, pageSize);

            return View(pageList);
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        public async Task<IActionResult> EditHotelRoom(int RoomNumber, int HotelID)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoomId(HotelID, RoomNumber);

            var hotels = await _hotels.GetAllHotels();

            var rooms = await _room.GetRooms();

            ViewBag.Hotels = hotels;
            ViewBag.Rooms = rooms;

            return View(hotelRoom);

            //var hotelRoomToEdit = await _hotelRoom.UpdateHotelRoom(HotelID, RoomNumber, hotelRoom);
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> EditHotelRoom(HotelRoomDTO hotelRoom, List<IFormFile> images)
        {
            
                var newHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelRoom.HotelID, hotelRoom.RoomNumber, hotelRoom);

                if (images.Count > 0)
                {
                    await _addImage.UploadHotelRoomImages(images, newHotelRoom);
                }
                return RedirectToAction("ListHotelRooms", "HotelRooms");
            //}
            //else
            //{
            //    var hotels = await _hotels.GetAllHotels();

            //    var rooms = await _room.GetRooms();

            //    ViewBag.Hotels = hotels;
            //    ViewBag.Rooms = rooms;

            //    return View();
            //}
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> DeleteHotelRoom(int HotelID, int RoomNumber)
        {
            await _hotelRoom.DeleteHotelRoom(HotelID, RoomNumber);

            return RedirectToAction("ListHotelRooms", "HotelRooms");
        }

    }
}
 