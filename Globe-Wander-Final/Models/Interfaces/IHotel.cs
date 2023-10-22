using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> CreateHotel(NewHotelDTO hotelDTO);

        Task<List<HotelDTO>> GetAllHotels();

        Task<HotelDTO> GetHotelId(int hotelId);

        Task<HotelDTO> UpdateHotel(int id, HotelDTO updatedHotel);

        Task<Hotel> DeleteHotel(int id);

        Task<List<AnonymousHotelDTO>> AnonymousHotelDTOs();

        Task<List<Facility>> GetAllFacilities();

        //Task<HotelDTO> UpdateHotelFacility();

        Task<List<HotelFacility>> GetAllHotelFacilityByHotelId(int hotelId);

        Task AddHotelFacility(HotelFacility hotelFacility);

        Task RemoveHotelFacility(HotelFacility hotelFacility);
    }
}
