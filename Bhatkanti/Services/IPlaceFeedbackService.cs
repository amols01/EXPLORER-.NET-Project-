using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IPlaceFeedbackService
    {
        Task<IEnumerable<Place_Feedbacks>> GetAllPlaceFeedbacksAsync();
        Task<Place_Feedbacks> GetPlaceFeedbackByIdAsync(int id);
        Task<Place_Feedbacks> CreatePlaceFeedbackAsync(Place_Feedbacks placeFeedback);
        Task<Place_Feedbacks> UpdatePlaceFeedbackAsync(Place_Feedbacks placeFeedback);
        Task DeletePlaceFeedbackAsync(int id);
    }
}
