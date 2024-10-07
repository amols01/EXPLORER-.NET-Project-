using Bhatkanti_.Models;

namespace Bhatkanti_.Services
{
    public interface IPlaceFeedbackService
    {
        Task AddPlaceFeedbackAsync(PlaceFeedback placeFeedback);
        Task<PlaceFeedback?> GetPlaceFeedbackByIdAsync(int id);
        Task<IEnumerable<PlaceFeedback>> GetFeedbacksByPlaceAsync(int placeId);
    }
}