using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.ServicesImpl
{
    public class GuideFeedbackService : IGuideFeedbackService
    {
        private readonly TravelGuideContext _context;

        public GuideFeedbackService(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task<GuideFeedback> CreateFeedbackAsync(GuideFeedback feedback)
        {
            _context.GuideFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<IEnumerable<GuideFeedback>> GetFeedbacksByGuideIdAsync(int guideId)
        {
            return await _context.GuideFeedbacks
                .Include(f => f.User)
                .Include(f => f.Guide)
                .Where(f => f.GuideId == guideId)
                .ToListAsync();
        }

        public async Task<GuideFeedback> GetFeedbackByIdAsync(int id)
        {
            return await _context.GuideFeedbacks
                .Include(f => f.User)
                .Include(f => f.Guide)
                .FirstOrDefaultAsync(f => f.FeedbackId == id);
        }
    }
}