using Bhatkanti_.Models;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User user);
        Task<User?> AuthenticateUserAsync(string email, string password);

        Task<User?> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}