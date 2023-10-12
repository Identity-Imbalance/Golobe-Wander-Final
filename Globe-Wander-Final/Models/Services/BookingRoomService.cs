﻿using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Globe_Wander_Final.Models.Services
{
    public class BookingRoomService : IBookingRoom
    {
        private readonly GlobeWanderDbContext _context;

        private UserManager<ApplicationUser> _UserManager;

        public BookingRoomService(GlobeWanderDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _UserManager = userManager;
        }

        /// <summary>
        /// Create a new booking room.
        /// </summary>
        /// <param name="bookingRoomDTO">Data for the new booking room.</param>
        /// <param name="userId">ID of the user making the booking.</param>
        public async Task<BookingRoomDTO> CreateBookingRoom(NewBookingRoomDTO bookingRoomDTO, string userId)
        {
            var getHotelRoom = await _context.HotelRooms.FindAsync(bookingRoomDTO.HotelID, bookingRoomDTO.RoomNumber);
            if (getHotelRoom == null)
            {
                return null;
            }

            var user = await _UserManager.FindByIdAsync(userId);

            var hotelRoom = await _context.HotelRooms.FindAsync(bookingRoomDTO.HotelID, bookingRoomDTO.RoomNumber);

            var existBookingRoom = await _context.BookingRooms
                                    .Where(x => x.Username == user.UserName)
                                    .FirstOrDefaultAsync(b => b.Username == user.UserName && b.HotelID == hotelRoom.HotelID);
            if (existBookingRoom == null)
            {
                if (getHotelRoom.IsAvailable)
                {
                    var bookingRoom = new BookingRoom
                    {
                        HotelID = bookingRoomDTO.HotelID,
                        RoomNumber = bookingRoomDTO.RoomNumber,
                        Cost = getHotelRoom.PricePerDay,
                        Duration = bookingRoomDTO.Duration,
                        TotalPrice = getHotelRoom.PricePerDay * bookingRoomDTO.Duration,
                        Username = user.UserName
                    };
                    getHotelRoom.IsAvailable = false;
                    _context.BookingRooms.Add(bookingRoom);
                    await _context.SaveChangesAsync();

                    var newBookingRoom = await GetBookingRoomById(bookingRoom.ID);

                    return newBookingRoom;
                }
                return null;
            }
            return null;

        }

        /// <summary>
        /// Delete a booking room by its ID.
        /// </summary>
        /// <param name="id">ID of the booking room to delete.</param>
        public async Task DeleteBookingRoom(int id)
        {
            var deleteBookingRoom = await _context.BookingRooms.FindAsync(id);

            var hotelRoom = await _context.HotelRooms.FindAsync(deleteBookingRoom.HotelID, deleteBookingRoom.RoomNumber);

            if (deleteBookingRoom != null)
            {
                hotelRoom.IsAvailable = true;
                _context.Entry(deleteBookingRoom).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a list of all booking rooms.
        /// </summary>
        public async Task<List<BookingRoomDTO>> GetAllBookingRooms()
        {

            var bookingRooms = await _context.BookingRooms.ToListAsync();
            var bookingRoomDTOs = bookingRooms.Select(bookingRoom => new BookingRoomDTO
            {
                ID = bookingRoom.ID,
                HotelID = bookingRoom.HotelID,
                RoomNumber = bookingRoom.RoomNumber,
                Cost = bookingRoom.Cost,
                Duration = bookingRoom.Duration,
                TotalPrice = bookingRoom.TotalPrice,
                Username = bookingRoom.Username


            }).ToList();

            return bookingRoomDTOs;
        }

        /// <summary>
        /// Get a booking room by its ID.
        /// </summary>
        /// <param name="id">ID of the booking room.</param>
        /// <param name="userId">ID of the user.</param>
        public async Task<BookingRoomDTO> GetBookingRoomById(int id)
        {
            var bookingRoom = await _context.BookingRooms.FindAsync(id);
            if (bookingRoom == null)
            {
                return null;
            }

            var bookingRoomDTO = new BookingRoomDTO
            {
                ID = bookingRoom.ID,
                HotelID = bookingRoom.HotelID,
                RoomNumber = bookingRoom.RoomNumber,
                Cost = bookingRoom.Cost,
                Duration = bookingRoom.Duration,
                TotalPrice = bookingRoom.TotalPrice,
                Username = bookingRoom.Username
            };

            return bookingRoomDTO;
        }

        /// <summary>
        /// Update a booking room's duration.
        /// </summary>
        /// <param name="id">ID of the booking room.</param>
        /// <param name="updatedBookingRoomDTO">Updated booking room data.</param>
        /// <param name="userId">ID of the user making the update.</param>
        // user cannot update the booking room 
        public async Task<BookingRoomDTO> UpdateBookingRoom(int id, DurationBookingRoomDTO updatedBookingRoomDTO)
        {
            var bookingRoom = await _context.BookingRooms.FindAsync(id);

            if (bookingRoom != null)
            {
                bookingRoom.Duration = updatedBookingRoomDTO.Duration;
                bookingRoom.TotalPrice = updatedBookingRoomDTO.Duration * bookingRoom.Cost;
                _context.Entry(bookingRoom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            var newBookingRoomUpdate = await GetBookingRoomById(id);
            return newBookingRoomUpdate;
        }
    }
}
