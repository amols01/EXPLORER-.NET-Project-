using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceFeedbackController : ControllerBase
    {
        private readonly IPlaceFeedbackService _placeFeedbackService;

        public PlaceFeedbackController(IPlaceFeedbackService placeFeedbackService)
        {
            _placeFeedbackService = placeFeedbackService;
        }

        // POST: api/PlaceFeedback
        [HttpPost]
        public async Task<IActionResult> CreatePlaceFeedback([FromBody] PlaceFeedback placeFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _placeFeedbackService.AddPlaceFeedbackAsync(placeFeedback);
            return Ok(placeFeedback);
        }

        // GET: api/PlaceFeedback/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaceFeedback(int id)
        {
            var placeFeedback = await _placeFeedbackService.GetPlaceFeedbackByIdAsync(id);
            if (placeFeedback == null)
            {
                return NotFound();
            }
            return Ok(placeFeedback);
        }

        // GET: api/PlaceFeedback/location/{placeId}
        [HttpGet("location/{placeId}")]
        public async Task<IActionResult> GetFeedbacksByPlace(int placeId)
        {
            var feedbacks = await _placeFeedbackService.GetFeedbacksByPlaceAsync(placeId);
            return Ok(feedbacks);
        }
    }
}