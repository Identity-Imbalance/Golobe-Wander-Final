namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IAddImage
    {
        Task<T> UploadImage<T>(IFormFile file, T Model) where T : IHasImage;
    }
    public interface IHasImage
    {
        string? ImageURL { get; set; }
    }
}
