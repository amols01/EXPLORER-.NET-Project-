using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IProfileService
    {
        Task<bool> UpdateProfileAsync(Users request);

    }
}
