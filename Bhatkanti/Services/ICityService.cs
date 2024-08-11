using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface ICityService
    {
        Task<IEnumerable<Cities>> GetAllCitiesAsync();
        Task<Cities> GetCityByIdAsync(int id);
        Task<Cities> CreateCityAsync(Cities city);
        Task<Cities> UpdateCityAsync(Cities city);
        Task DeleteCityAsync(int id);
    }
}
