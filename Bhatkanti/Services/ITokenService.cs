using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface ITokenService
    {
        string GenerateToken(Guide guide);

    }
}
