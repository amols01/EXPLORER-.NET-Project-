using Bhatkanti.Models;
using Bhatkanti.Services;

namespace Bhatkanti.ServicesImpl
{
    public class ProfileServiceImpl : IProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateProfileAsync(Users request)
        {
            var user = await _context.Users.FindAsync(request.User_ID);
            if (user == null)
            {
                return false;
            }

            user.Username = request.Username;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            // Update other fields as necessary

            _context.Users.Update(user);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log exception if necessary
                return false;
            }
        }
    }
}
