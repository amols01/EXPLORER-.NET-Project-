using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IBookingPaymentDetailService
    {
        Task<IEnumerable<Booking_Payment_Details>> GetAllBookingPaymentDetailsAsync();
        Task<Booking_Payment_Details> GetBookingPaymentDetailByIdAsync(int id);
        Task<Booking_Payment_Details> CreateBookingPaymentDetailAsync(Booking_Payment_Details bookingPaymentDetail);
        Task<Booking_Payment_Details> UpdateBookingPaymentDetailAsync(Booking_Payment_Details bookingPaymentDetail);
        Task DeleteBookingPaymentDetailAsync(int id);
    }
}
