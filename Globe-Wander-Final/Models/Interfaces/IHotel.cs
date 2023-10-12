﻿using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IHotel
    {
        Task<NewHotelDTO> CreateHotel(NewHotelDTO hotelDTO);

        Task<List<HotelDTO>> GetAllHotels();

        Task<HotelDTO> GetHotelId(int hotelId);

        Task<HotelDTO> UpdateHotel(int id, HotelDTO updatedHotel);

        Task<Hotel> DeleteHotel(int id);

        Task<List<AnonymousHotelDTO>> AnonymousHotelDTOs();
    }
}
