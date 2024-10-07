using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IFeedbackService
    {
        // Get feedbacks for a specific place
        Task<IEnumerable<Place_Feedbacks>> GetPlaceFeedbacksAsync(int placeId);

        // Get feedbacks for a specific guide
        Task<IEnumerable<Guide_Feedbacks>> GetGuideFeedbacksAsync(int guideId);

        // Add feedback for a place
        Task<bool> AddPlaceFeedbackAsync(Place_Feedbacks request);

        // Add feedback for a guide
        Task<bool> AddGuideFeedbackAsync(Guide_Feedbacks request);

        // Add feedback for a guide    }   
    }
}
