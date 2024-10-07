using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhatkanti.ServicesImpl
{
    public class UserGuideBookingsServiceImpl : IUserGuideBookingsService
    {
        private readonly ApplicationDbContext _context;

        public UserGuideBookingsServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<User_Guide_Bookings>> GetUserGuideBookingsByGuideIdAsync(int guideId)
        {
            return await _context.User_Guide_Bookings
                                 .Where(ugb => ugb.Guide_ID == guideId)
                                 .ToListAsync();
        }
        public async Task<bool> BookGuideAsync(User_Guide_Bookings bookingRequest)
        {
            try
            {
                var guide = await _context.Guides.FindAsync(bookingRequest.Guide_ID);
                var user = await _context.Users.FindAsync(bookingRequest.User_ID);
                var bill = await _context.Bills.FindAsync(bookingRequest.Bill_ID);

                if (guide == null || user == null || bill == null)
                {
                    return false;
                }

                var newBooking = new User_Guide_Bookings
                {
                    User_ID = bookingRequest.User_ID,
                    Guide_ID = bookingRequest.Guide_ID,
                    Date_From = bookingRequest.Date_From,
                    Date_To = bookingRequest.Date_To,
                    Time_From = bookingRequest.Time_From,
                    Time_To = bookingRequest.Time_To,
                    Bill_ID = bookingRequest.Bill_ID,
                    // Set other properties as needed
                };

                _context.User_Guide_Bookings.Add(newBooking);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (if you have a logging mechanism)
                return false;
            }
        }


        public async Task<User_Guide_Bookings> GetBookingByIdAsync(int bookingId)
        {
            return await _context.User_Guide_Bookings
                .Include(b => b.Guide)
                .Include(b => b.User)
                .Include(b => b.Bill)
                .FirstOrDefaultAsync(b => b.Booking_ID == bookingId);
        }
        public async Task<IEnumerable<User_Guide_Bookings>> GetAllUserGuideBookingsAsync()
        {
            return await _context.User_Guide_Bookings.ToListAsync();
        }

        public async Task<User_Guide_Bookings> GetUserGuideBookingByIdAsync(int id)
        {
            return await _context.User_Guide_Bookings.FindAsync(id);
        }

        public async Task<User_Guide_Bookings> CreateUserGuideBookingAsync(User_Guide_Bookings userGuideBooking)
        {
            _context.User_Guide_Bookings.Add(userGuideBooking);
            await _context.SaveChangesAsync();
            return userGuideBooking;
        }

        public async Task<User_Guide_Bookings> UpdateUserGuideBookingAsync(User_Guide_Bookings userGuideBooking)
        {
            _context.User_Guide_Bookings.Update(userGuideBooking);
            await _context.SaveChangesAsync();
            return userGuideBooking;
        }

        public async Task DeleteUserGuideBookingAsync(int id)
        {
            var userGuideBooking = await _context.User_Guide_Bookings.FindAsync(id);
            if (userGuideBooking != null)
            {
                _context.User_Guide_Bookings.Remove(userGuideBooking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
