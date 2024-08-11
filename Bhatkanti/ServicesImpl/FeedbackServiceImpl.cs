using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class FeedbackServiceImpl : IFeedbackService
    {
        private readonly ApplicationDbContext _context;        

        public FeedbackServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get feedbacks for a specific location
        public async Task<IEnumerable<Place_Feedbacks>> GetPlaceFeedbacksAsync(int locationId)
        {
            return await _context.Place_Feedbacks
                .Where(f => f.Place_Feedback_ID == locationId)
                .ToListAsync();
        }

        // Get feedbacks for a specific guide
        public async Task<IEnumerable<Guide_Feedbacks>> GetGuideFeedbacksAsync(int guideId)
        {
            return await _context.Guide_Feedbacks
                .Where(f => f.Guide_Feedback_ID == guideId)
                .ToListAsync();
        }

        // Add feedback for a location
        public async Task<bool> AddPlaceFeedbackAsync(Place_Feedbacks request)
        {
            var feedback = new Place_Feedbacks
            {
                Place_Feedback_ID = request.Place_Feedback_ID,
                User_ID = request.User_ID,
                Place_Feedback = request.Place_Feedback,
                Place_Rating = request.Place_Rating,
                Timestamp = DateTime.UtcNow
            };

            _context.Place_Feedbacks.Add(feedback);

            //// Handle image uploads if necessary
            //if (request. != null && request.Images.Any())
            //{
            //    foreach (var image in request.Images)
            //    {
            //        // Assuming you have a method to handle image upload
            //        var imageUrl = await UploadImageAsync(image);
            //        var feedbackImage = new FeedbackImage
            //        {
            //            FeedbackId = feedback.FeedbackId,
            //            ImageUrl = imageUrl
            //        };
            //        _context.FeedbackImages.Add(feedbackImage);
            //    }
            //}

            return await _context.SaveChangesAsync() > 0;
        }

        // Add feedback for a guide
        public async Task<bool> AddGuideFeedbackAsync(Guide_Feedbacks request)
        {
            var feedback = new Guide_Feedbacks
            {
                Guide_ID = request.Guide_ID,
                User_ID = request.User_ID,
                Guide_Feedback = request.Guide_Feedback,
                Guide_Rating = request.Guide_Rating,
                Timestamp = DateTime.UtcNow
            };

            _context.Guide_Feedbacks.Add(feedback);
            return await _context.SaveChangesAsync() > 0;
        }

        // Method to handle image uploads (implementation depends on your setup)
        private Task<string> UploadImageAsync(IFormFile image)
        {
            // Implement image upload logic here
            throw new NotImplementedException();
        }
    }
}
