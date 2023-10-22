using Globe_Wander_Final.Data;
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

            var hotelRoom = await _context.HotelRooms.FindAsync(bookingRoomDTO.HotelID, bookingRoomDTO.RoomNumber);


            if (null == null)
            {

                TimeSpan duration = bookingRoomDTO.CheckOut - bookingRoomDTO.CheckIn;
                int totalDays = (int)duration.TotalDays;
                if (totalDays < 1)
                {
                    return null;
                }

                 
             
                if (getHotelRoom.IsAvailable)
                {
                    var bookingRoom = new BookingRoom
                    {
                        HotelID = bookingRoomDTO.HotelID,
                        RoomNumber = bookingRoomDTO.RoomNumber,
                        Cost = getHotelRoom.PricePerDay,
                        Duration = totalDays,
                        CheckIn=bookingRoomDTO.CheckIn,
                        CheckOut=bookingRoomDTO.CheckOut,
                        TotalPrice = getHotelRoom.PricePerDay * totalDays,
                        Username = userId
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
                CheckIn = bookingRoom.CheckIn,
                CheckOut = bookingRoom.CheckOut,
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
                CheckOut = bookingRoom.CheckOut,
                CheckIn = bookingRoom.CheckIn,
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
                TimeSpan duration = updatedBookingRoomDTO.CheckOut - updatedBookingRoomDTO.CheckIn;
                int totalDays = (int)duration.TotalDays;
                if (totalDays < 1)
                {
                    return null;
                }



                bookingRoom.Duration = totalDays;
                bookingRoom.CheckOut = updatedBookingRoomDTO.CheckOut;
                bookingRoom.CheckIn = updatedBookingRoomDTO.CheckIn;
                bookingRoom.TotalPrice = totalDays * bookingRoom.Cost;
                _context.Entry(bookingRoom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            var newBookingRoomUpdate = await GetBookingRoomById(id);
            return newBookingRoomUpdate;
        }

        public async Task<List<BookingRoomDTO>> GetAllBookingRoomsForUser(string userId)
        {

            var bookingRooms = await _context.BookingRooms.ToListAsync();
            var bookingRoomDTOs =  bookingRooms.Where(x=>userId == x.Username).Select(bookingRoom => new BookingRoomDTO
            {
                ID = bookingRoom.ID,
                HotelID = bookingRoom.HotelID,
                RoomNumber = bookingRoom.RoomNumber,
                Cost = bookingRoom.Cost,
                CheckIn = bookingRoom.CheckIn,
                CheckOut = bookingRoom.CheckOut,
                Duration = bookingRoom.Duration,
                TotalPrice = bookingRoom.TotalPrice,
                Username = bookingRoom.Username


            }).ToList();

            return bookingRoomDTOs;
        }

    }
}
