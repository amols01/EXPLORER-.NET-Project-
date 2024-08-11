using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IHelpService
    {
        Task<IEnumerable<Help>> GetAllHelpQueriesAsync();
        Task<Help> GetHelpQueryByIdAsync(int id);
        Task<Help> CreateHelpQueryAsync(Help help);
        Task<Help> UpdateHelpQueryAsync(Help help);
        Task DeleteHelpQueryAsync(int id);
    }
}