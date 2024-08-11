using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> GetAllPlacesAsync();
        Task<Place> GetPlaceByIdAsync(int id);
        Task<IEnumerable<Place>> GetLocationsByCityAsync(int cityId);

        Task<Place> CreatePlaceAsync(Place place);
        Task<Place> UpdatePlaceAsync(Place place);
        Task DeletePlaceAsync(int id);
    }
}
