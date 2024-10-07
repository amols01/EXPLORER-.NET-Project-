using Bhatkanti_.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface IGuideFeedbackService
    {
        Task<GuideFeedback> CreateFeedbackAsync(GuideFeedback feedback);
        Task<IEnumerable<GuideFeedback>> GetFeedbacksByGuideIdAsync(int guideId);
        Task<GuideFeedback> GetFeedbackByIdAsync(int id);
    }
}