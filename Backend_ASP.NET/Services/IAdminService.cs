using Bhatkanti_.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<bool> AuthenticateAsync(string email, string password);
        Task<Admin> GetAdminByEmailAsync(string email);
        Task<bool> DeleteAdminAsync(string email);
        Task CreateAdminAsync(Admin admin);
        Task<bool> CreateGuideAsync(Guide guide);
        Task<Guide?> GetGuideByIdAsync(int guideId);
        Task<IEnumerable<Guide>> GetAllGuidesAsync();
        Task<bool> UpdateGuideAsync(Guide guide);
        Task<bool> DeleteGuideAsync(int guideId);
    }
}
