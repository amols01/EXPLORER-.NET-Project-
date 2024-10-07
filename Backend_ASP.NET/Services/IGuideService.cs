using Bhatkanti_.Models;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface IGuideService
    {
        Task<bool> RegisterGuideAsync(Guide request);
        Task<Guide?> AuthenticateAsync(string email, string password);
    }
}
