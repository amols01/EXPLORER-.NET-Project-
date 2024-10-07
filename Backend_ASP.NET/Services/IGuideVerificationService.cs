using Bhatkanti_.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface IGuideVerificationService
    {
        Task<bool> CreateVerificationAsync(GuideVerification verification);
        Task<GuideVerification?> GetVerificationByIdAsync(string aadharNumber);
        Task<IEnumerable<GuideVerification>> GetAllVerificationsAsync();
        Task<bool> UpdateVerificationAsync(GuideVerification verification);
        Task<bool> DeleteVerificationAsync(string aadharNumber);
    }
}
