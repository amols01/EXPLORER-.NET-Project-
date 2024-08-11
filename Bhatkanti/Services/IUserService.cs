using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IUserService
    {
        Task<Guide> AuthenticateGuideAsync(string email, string password);
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<Users> CreateUserAsync(Users user);
        Task<Users> UpdateUserAsync(Users user);
        Task<bool> DeleteUserAsync(int id);
        Task<Users> AuthenticateAsync(string email, string password);
        Task<Users> GetUserByEmailAsync(string email);
    }
}
