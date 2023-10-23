using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IAddImage
    {
        Task<TourSpot> UploadImage(IFormFile file, TourSpot Model);

        Task<Hotel> UploadHotelImages(List<IFormFile> files, Hotel Model);

        Task<HotelRoomDTO> UploadHotelRoomImages(List<IFormFile> files, HotelRoomDTO Model);

        Task<Image> AddHotelImage(string imageURL, Hotel hotel);

        Task<Image> AddHotelRoomImage(string imageURL, HotelRoomDTO hotelRoom);

        Task<HotelDTO> UpdateHotelImages(List<IFormFile> files, HotelDTO Model);

        Task<TripDTO> UploadTripImages(List<IFormFile> files, TripDTO Model);

        Task<TripDTO> UpdateTripImages(List<IFormFile> files, TripDTO Model);

        Task<UserUpdateDTO> UpdateProfileImage(IFormFile file, UserUpdateDTO model);

    }
    public interface IHasImage
    {
        string? ImageURL { get; set; }
    }
}
