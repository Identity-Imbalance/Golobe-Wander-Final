using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> CreateRoom(RoomDTO room);

        Task<List<RoomDTO>> GetRooms();

        Task<RoomDTO> GetRoomId(int roomId);

        Task<RoomDTO> UpdateRoom(int roomId, RoomDTO room);

        Task<RoomDTO> DeleteRoom(int roomId);

    }
}
