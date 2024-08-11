using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IUserGuideBookingsService
    {
        Task<bool> BookGuideAsync(User_Guide_Bookings request);
        Task<User_Guide_Bookings> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<User_Guide_Bookings>> GetAllUserGuideBookingsAsync();
        Task<User_Guide_Bookings> GetUserGuideBookingByIdAsync(int id);
        Task<User_Guide_Bookings> CreateUserGuideBookingAsync(User_Guide_Bookings userGuideBooking);
        Task<User_Guide_Bookings> UpdateUserGuideBookingAsync(User_Guide_Bookings userGuideBooking);
        Task DeleteUserGuideBookingAsync(int id);

        Task<IEnumerable<User_Guide_Bookings>> GetUserGuideBookingsByGuideIdAsync(int guideId);
    }
}
