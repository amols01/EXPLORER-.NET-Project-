using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideFeedbackController : ControllerBase
    {
        private readonly IGuideFeedbackService _feedbackService;

        public GuideFeedbackController(IGuideFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] GuideFeedback feedback)
        {
            if (feedback == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var createdFeedback = await _feedbackService.CreateFeedbackAsync(feedback);
            return Ok(createdFeedback);
        }

        [HttpGet("guide/{guideId}")]
        public async Task<ActionResult<IEnumerable<GuideFeedback>>> GetFeedbacksByGuideId(int guideId)
        {
            var feedbacks = await _feedbackService.GetFeedbacksByGuideIdAsync(guideId);
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound("Feedback not found.");
            }
            return Ok(feedback);
        }
    }
}