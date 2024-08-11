using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IPlaceImageService
    {
        Task<IEnumerable<Place_Images>> GetAllPlaceImagesAsync();
        Task<Place_Images> GetPlaceImageByIdAsync(int id);
        Task<Place_Images> CreatePlaceImageAsync(Place_Images placeImage);
        Task<Place_Images> UpdatePlaceImageAsync(Place_Images placeImage);
        Task DeletePlaceImageAsync(int id);
    }
}
