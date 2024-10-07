using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti_.ServicesImpl
{
    public class PlaceFeedbackServiceImpl : IPlaceFeedbackService
    {
        private readonly TravelGuideContext _context;

        public PlaceFeedbackServiceImpl(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task AddPlaceFeedbackAsync(PlaceFeedback placeFeedback)
        {
            placeFeedback.FeedbackDate = DateTime.Now;
            _context.PlaceFeedbacks.Add(placeFeedback);
            await _context.SaveChangesAsync();
        }

        public async Task<PlaceFeedback?> GetPlaceFeedbackByIdAsync(int id)
        {
            return await _context.PlaceFeedbacks
                .Include(pf => pf.User)
                .Include(pf => pf.Location)
                .FirstOrDefaultAsync(pf => pf.PlaceFeedbackId == id);
        }

        public async Task<IEnumerable<PlaceFeedback>> GetFeedbacksByPlaceAsync(int placeId)
        {
            return await _context.PlaceFeedbacks
                .Where(pf => pf.PlaceId == placeId)
                .Include(pf => pf.User)
                .ToListAsync();
        }
    }
}