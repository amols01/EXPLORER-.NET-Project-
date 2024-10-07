using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class BookingPlaceGuideServiceImpl : IBookingPlaceGuideService
    {
        private readonly ApplicationDbContext _context;

        public BookingPlaceGuideServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User_Guide_Bookings>> GetBookingsByGuideIdAsync(int guideId)
        {
            return await _context.User_Guide_Bookings
                                 .Where(ugb => ugb.Guide_ID == guideId)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Booking_Place_Guide>> GetAllBookingsAsync()
        {
            return await _context.Booking_Place_Guide.ToListAsync();
               
        }

        public async Task<Booking_Place_Guide> GetBookingByIdAsync(int id)
        {
            return await _context.Booking_Place_Guide.FindAsync(id);
        }

        public async Task<Booking_Place_Guide> CreateBookingAsync(Booking_Place_Guide booking)
        {
            _context.Booking_Place_Guide.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking_Place_Guide> UpdateBookingAsync(Booking_Place_Guide booking)
        {
            _context.Booking_Place_Guide.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Booking_Place_Guide.FindAsync(id);
            if (booking != null)
            {
                _context.Booking_Place_Guide.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
