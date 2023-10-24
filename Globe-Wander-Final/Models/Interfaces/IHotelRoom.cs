using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTOCreate hotelRoom);

        Task<List<HotelRoomDTO>> GetHotelRooms();

        Task<HotelRoomDTO> GetHotelRoomId(int hotelID, int roomNumber);

        Task<HotelRoomDTO> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoomDTO hotelRoom);

        Task<HotelRoom> DeleteHotelRoom(int hotelID, int roomNumber);

        Task<List<AnonymousHotelRoomDTO>> GetAnonymousHotelRoomDTO();
    }
}
