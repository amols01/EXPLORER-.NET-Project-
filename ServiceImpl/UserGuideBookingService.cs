using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bhatkanti_.ServicesImpl
{
    public class UserGuideBookingService : IUserGuideBookingService
    {
        private readonly TravelGuideContext _context;

        public UserGuideBookingService(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task<bool> BookGuideAsync(UserGuideBooking booking)
        {
            _context.UserGuideBookings.Add(booking);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            var booking = await _context.UserGuideBookings.FindAsync(bookingId);
            if (booking == null) return false;

            _context.UserGuideBookings.Remove(booking);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UserGuideBooking?> GetBookingByIdAsync(int bookingId)
        {
            return await _context.UserGuideBookings
                .Include(b => b.Guide)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }

        public async Task<bool> UpdateBookingAsync(int bookingId, UserGuideBooking booking)
        {
            var existingBooking = await _context.UserGuideBookings.FindAsync(bookingId);
            if (existingBooking == null) return false;

            existingBooking.Location = booking.Location;
            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.BookingStartTime = booking.BookingStartTime;
            existingBooking.BookingEndTime = booking.BookingEndTime;
            // Add other fields as needed

            _context.UserGuideBookings.Update(existingBooking);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}