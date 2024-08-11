using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class BookingPaymentDetailServiceImpl : IBookingPaymentDetailService
    {
        private readonly ApplicationDbContext _context;

        public BookingPaymentDetailServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking_Payment_Details>> GetAllBookingPaymentDetailsAsync()
        {
            return await _context.Booking_Payment_Details.ToListAsync();
        }

        public async Task<Booking_Payment_Details> GetBookingPaymentDetailByIdAsync(int id)
        {
            return await _context.Booking_Payment_Details.FindAsync(id);
        }

        public async Task<Booking_Payment_Details> CreateBookingPaymentDetailAsync(Booking_Payment_Details bookingPaymentDetail)
        {
            _context.Booking_Payment_Details.Add(bookingPaymentDetail);
            await _context.SaveChangesAsync();
            return bookingPaymentDetail;
        }

        public async Task<Booking_Payment_Details> UpdateBookingPaymentDetailAsync(Booking_Payment_Details bookingPaymentDetail)
        {
            _context.Booking_Payment_Details.Update(bookingPaymentDetail);
            await _context.SaveChangesAsync();
            return bookingPaymentDetail;
        }

        public async Task DeleteBookingPaymentDetailAsync(int id)
        {
            var bookingPaymentDetail = await _context.Booking_Payment_Details.FindAsync(id);
            if (bookingPaymentDetail != null)
            {
                _context.Booking_Payment_Details.Remove(bookingPaymentDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
