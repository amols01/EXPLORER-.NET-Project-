using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IGuideService
    {
        Task<decimal> GetTotalEarningsAsync(int guideId);

        Task<IEnumerable<Guide>> GetAllGuidesAsync();
        Task<Guide> GetGuideByIdAsync(int id);
        Task<Guide> CreateGuideAsync(Guide guide);
        Task<Guide> UpdateGuideAsync(Guide guide);
        Task DeleteGuideAsync(int id);
    }
}
