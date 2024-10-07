using System.Collections.Generic;
using System.Threading.Tasks;
using Bhatkanti_.Models;

namespace Bhatkanti_.Services
{
    public interface ICityService
    {
        Task<City> GetCityByIdAsync(int cityId);
        Task<City> AddCityAsync(City city);
        Task<City> UpdateCityAsync(City city);
        Task<bool> DeleteCityAsync(int cityId);
        Task<IEnumerable<City>> GetAllCitiesAsync();
    }
}
