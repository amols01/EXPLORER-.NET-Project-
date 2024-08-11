using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IBookingPlaceGuideService
    {
        Task<IEnumerable<Booking_Place_Guide>> GetAllBookingsAsync();
        Task<Booking_Place_Guide> GetBookingByIdAsync(int id);
        Task<IEnumerable<User_Guide_Bookings>> GetBookingsByGuideIdAsync(int guideId);
        Task<Booking_Place_Guide> CreateBookingAsync(Booking_Place_Guide booking);
        Task<Booking_Place_Guide> UpdateBookingAsync(Booking_Place_Guide booking);
        Task DeleteBookingAsync(int id);
    }
}
