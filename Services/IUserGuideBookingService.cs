using Bhatkanti_.Models;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface IUserGuideBookingService
    {
        Task<bool> BookGuideAsync(UserGuideBooking booking);
        Task<bool> CancelBookingAsync(int bookingId);
        Task<UserGuideBooking?> GetBookingByIdAsync(int bookingId);
        Task<bool> UpdateBookingAsync(int bookingId, UserGuideBooking booking);
    }
}