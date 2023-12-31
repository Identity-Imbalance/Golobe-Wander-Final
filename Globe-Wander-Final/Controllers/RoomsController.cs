﻿using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Globe_Wander_Final.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoom _room;
        public RoomsController(IRoom room)
        {
            _room = room;
        }
        public async Task<IActionResult> CreateRoom()
        {
            var amenities = await _room.GetAllAmenities();

            ViewBag.Amenities = amenities;

            return View();
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomDTO model, List<int> selectedAmentias)
        {
            //if (ModelState.IsValid)
            //{
                var room = await _room.CreateRoom(model);

                var existRoomAmenities = await _room.GetAllRoomAmenitiesById(room.ID);
                foreach (var amenityId in selectedAmentias)
                {
                    if (!existRoomAmenities.Any(rm=> rm.AmenityId == amenityId))
                    {
                        var newRoomAmenity = new RoomAmenity
                        {
                            RoomId = room.ID,
                            AmenityId = amenityId,
                        };
                        await _room.AddRoomAmenity(newRoomAmenity);
                    }
                }

                return RedirectToAction("CreateRoom", "Rooms");
        
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        public async Task<IActionResult> ListRooms(int? page)
        {
            var pageSize = 6;

            var pageNumber = page ?? 1;
            
            var rooms = await _room.GetRooms();

            var pageList = rooms.ToPagedList(pageNumber, pageSize);

            return View(pageList);
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        public async Task<IActionResult> EditRoom(int id)
        {
            var room = await _room.GetRoomId(id);
            var amenities = await _room.GetAllAmenities();

            ViewBag.Amenities = amenities;

            return View(room);
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> EditRoom(int id, RoomDTO model, List<int> selectedAmentias)
        {
            var room = await _room.UpdateRoom(id, model);

            var existRoomAmenities = await _room.GetAllRoomAmenitiesById(room.ID);
            foreach (var amenityId in selectedAmentias)
            {
                if (!existRoomAmenities.Any(rm => rm.AmenityId == amenityId))
                {
                    var newRoomAmenity = new RoomAmenity
                    {
                        RoomId = room.ID,
                        AmenityId = amenityId,
                    };
                    await _room.AddRoomAmenity(newRoomAmenity);
                }
            }


            foreach (var existRoomAmenity in existRoomAmenities)
            {
                if (!selectedAmentias.Contains(existRoomAmenity.AmenityId))
                {
                    await _room.RemoveRoomAmenity(existRoomAmenity);
                }
            }
            return RedirectToAction("ListRooms", "Rooms");
        }

        [Authorize(Roles = "Hotel Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);
            return RedirectToAction("ListRooms", "Rooms");
        }
    }
}
