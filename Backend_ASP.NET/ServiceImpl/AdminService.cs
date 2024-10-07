using Bhatkanti_.Data;
using Bhatkanti_.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti_.Services
{
    public class AdminService : IAdminService
    {
        private readonly TravelGuideContext _context;

        public AdminService(TravelGuideContext context)
        {
            _context = context;
        }
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var admin = await _context.Admins
                .SingleOrDefaultAsync(a => a.Email == email && a.Password == password);
            return admin != null;
        }
        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            return await _context.Admins.FindAsync(email);
        }

        public async Task CreateAdminAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAdminAsync(string email)
        {
            var admin = await _context.Admins.FindAsync(email);
            if (admin == null)
            {
                return false;
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CreateGuideAsync(Guide guide)
        {
            _context.Guides.Add(guide);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Guide?> GetGuideByIdAsync(int guideId)
        {
            return await _context.Guides
                .Include(g => g.GuideFeedbacks)
                .Include(g => g.Bills)
                .Include(g => g.GuideVerification)
                .FirstOrDefaultAsync(g => g.GuideId == guideId);
        }

        public async Task<IEnumerable<Guide>> GetAllGuidesAsync()
        {
            return await _context.Guides
                .Include(g => g.GuideFeedbacks)
                .Include(g => g.Bills)
                .Include(g => g.GuideVerification)
                .ToListAsync();
        }

        public async Task<bool> UpdateGuideAsync(Guide guide)
        {
            _context.Guides.Update(guide);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteGuideAsync(int guideId)
        {
            var guide = await _context.Guides.FindAsync(guideId);
            if (guide == null)
            {
                return false;
            }
            _context.Guides.Remove(guide);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
