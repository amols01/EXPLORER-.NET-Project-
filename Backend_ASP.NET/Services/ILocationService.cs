using Bhatkanti_.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<IEnumerable<Location>> GetLocationsByCityNameAsync(string cityName);
        Task<Location> GetLocationByLocationNameAsync(string placeName);
        Task<Location> AddLocationAsync(Location location);
        Task<bool> UpdateLocationAsync(int id, Location location);
        Task<bool> DeleteLocationAsync(int id);
        Task<bool> LocationExistsAsync(int id);
    }
}
