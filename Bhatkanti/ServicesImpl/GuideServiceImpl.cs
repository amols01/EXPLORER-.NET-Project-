using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhatkanti.ServicesImpl
{
    public class GuideServiceImpl : IGuideService
    {
        private readonly ApplicationDbContext _context;

        public GuideServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalEarningsAsync(int guideId)
        {
            return await _context.Bills
                .Where(b => b.Guide.Guide_ID == guideId)
                .SumAsync(b => b.Total_Bill_Amount);
        }

        public async Task<IEnumerable<Guide>> GetAllGuidesAsync()
        {
            return await _context.Guides.ToListAsync();
        }

        public async Task<bool> BookGuideAsync(User_Guide_Bookings bookingRequest)
        {
            try
            {
                // Ensure the guide and user are valid
                var guide = await _context.Guides.FindAsync(bookingRequest.Guide_ID);
                var user = await _context.Users.FindAsync(bookingRequest.User_ID);

                if (guide == null || user == null)
                {
                    return false;
                }

                // Create a new booking record
                var newBooking = new User_Guide_Bookings
                {
                    User_ID = bookingRequest.User_ID,
                    Guide_ID = bookingRequest.Guide_ID,
                    Date_From = bookingRequest.Date_From,
                    Date_To = bookingRequest.Date_To,
                    Time_From = bookingRequest.Time_From,
                    Time_To = bookingRequest.Time_To,
                    Bill_ID = bookingRequest.Bill_ID,
                    Timestamp = DateTime.Now // or use DateTime.UtcNow
                };

                _context.User_Guide_Bookings.Add(newBooking);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (if you have a logging mechanism)
                // For simplicity, just returning false
                return false;
            }
        }

        public async Task<Guide> GetGuideByIdAsync(int id)
        {
            return await _context.Guides.FindAsync(id);
        }

        public async Task<Guide> CreateGuideAsync(Guide guide)
        {
            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();
            return guide;
        }

        public async Task<Guide> UpdateGuideAsync(Guide guide)
        {
            _context.Guides.Update(guide);
            await _context.SaveChangesAsync();
            return guide;
        }

        public async Task DeleteGuideAsync(int id)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide != null)
            {
                _context.Guides.Remove(guide);
                await _context.SaveChangesAsync();
            }
        }
    }
}
