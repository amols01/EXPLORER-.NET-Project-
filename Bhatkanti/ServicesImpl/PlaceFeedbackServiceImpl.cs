using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class PlaceFeedbackServiceImpl :IPlaceFeedbackService
    {
        private readonly ApplicationDbContext _context;

        public PlaceFeedbackServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Place_Feedbacks>> GetAllPlaceFeedbacksAsync()
        {
            return await _context.Place_Feedbacks.ToListAsync();
        }

        public async Task<Place_Feedbacks> GetPlaceFeedbackByIdAsync(int id)
        {
            return await _context.Place_Feedbacks.FindAsync(id);
        }

        public async Task<Place_Feedbacks> CreatePlaceFeedbackAsync(Place_Feedbacks placeFeedback)
        {
            _context.Place_Feedbacks.Add(placeFeedback);
            await _context.SaveChangesAsync();
            return placeFeedback;
        }

        public async Task<Place_Feedbacks> UpdatePlaceFeedbackAsync(Place_Feedbacks placeFeedback)
        {
            _context.Place_Feedbacks.Update(placeFeedback);
            await _context.SaveChangesAsync();
            return placeFeedback;
        }

        public async Task DeletePlaceFeedbackAsync(int id)
        {
            var placeFeedback = await _context.Place_Feedbacks.FindAsync(id);
            if (placeFeedback != null)
            {
                _context.Place_Feedbacks.Remove(placeFeedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}
