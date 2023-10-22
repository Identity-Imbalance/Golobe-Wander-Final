using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IAddImage
    {
        Task<T> UploadImage<T>(IFormFile file, T Model) where T : IHasImage;

        Task<Hotel> UploadHotelImages(List<IFormFile> files, Hotel Model);

        Task<HotelRoomDTO> UploadHotelRoomImages(List<IFormFile> files, HotelRoomDTO Model);

        Task<Image> AddHotelImage(string imageURL, Hotel hotel);

        Task<Image> AddHotelRoomImage(string imageURL, HotelRoomDTO hotelRoom);

        Task<HotelDTO> UpdateHotelImages(List<IFormFile> files, HotelDTO Model);

    }
    public interface IHasImage
    {
        string? ImageURL { get; set; }
    }
}
