using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bhatkanti_.ServicesImpl
{
    public class GuideService : IGuideService
    {
        private readonly TravelGuideContext _context;

        public GuideService(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterGuideAsync(Guide request)
        {
            var guide = new Guide
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password, // Consider hashing passwords in production
                City = request.City,
                State = request.State,
                Timestamp = DateTime.UtcNow
            };

            _context.Guides.Add(guide);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<Guide?> AuthenticateAsync(string email, string password)
        {
            var guide = await _context.Guides
                .FirstOrDefaultAsync(g => g.Email == email && g.Password == password);
            return guide ;
        }
       

    }
}
