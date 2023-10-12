using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTOCreate hotelRoom);

        Task<List<HotelRoomDTO>> GetHotelRooms();

        Task<HotelRoomDTO> GetHotelRoomId(int hotelID, int roomNumber);

        Task<HotelRoomDTOCreate> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoomDTOCreate hotelRoom);

        Task<HotelRoom> DeleteHotelRoom(int hotelID, int roomNumber);

        Task<List<AnonymousHotelRoomDTO>> GetAnonymousHotelRoomDTO();
    }
}
