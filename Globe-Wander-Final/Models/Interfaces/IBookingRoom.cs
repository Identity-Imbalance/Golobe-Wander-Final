using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IBookingRoom
    {
        public Task<BookingRoomDTO> CreateBookingRoom(NewBookingRoomDTO bookingRoom, string userId);

        public Task<List<BookingRoomDTO>> GetAllBookingRooms();

        public Task<BookingRoomDTO> GetBookingRoomById(int Id);

        public Task<BookingRoomDTO> UpdateBookingRoom(int id, DurationBookingRoomDTO bookingRoom);

        public Task DeleteBookingRoom(int id);

        public Task<List<BookingRoomDTO>> GetAllBookingRoomsForUser(string userId);
    }
}
