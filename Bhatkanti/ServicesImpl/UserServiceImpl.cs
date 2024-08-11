using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync(); /*ToListAsync();*/
        }

        public async Task<Guide> AuthenticateGuideAsync(string email, string password)
        {
            // Retrieve user from database
            var user = await _context.Users
                .Include(u => u.Guide).
                Include(u => u.Role_ID) 
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;

            return user.Guide;
        }
        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Users> CreateUserAsync(Users user)
        {
            // Check if the Role_ID exists in the database
            var roleExists = await _context.M_Roles.AnyAsync(r => r.Role_ID == user.Role_ID);
            if (!roleExists)
            {
                throw new Exception("Invalid Role_ID.");
            }

            // Add the user
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateUserAsync(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Users> AuthenticateAsync(string email, string password)
        {
            // Simple authentication logic, you might want to use hashed passwords in a real application
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
