using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Bhatkanti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Traveler")]
    public class TravelerController : ControllerBase
    {
        private readonly IPlaceService _locationService;
        private readonly IFeedbackService _feedbackService;
        private readonly IGuideService _guideService;
        private readonly IWishlistService _wishlistService;
        private readonly IUserService _userService;
        private readonly IUserGuideBookingsService _userGuideBookingsService;
        private readonly IProfileService _profileService;

        public TravelerController(
            IUserService userService,
            IPlaceService locationService,
            IFeedbackService feedbackService,
            IGuideService guideService,
            IWishlistService wishlistService,
            IUserGuideBookingsService userGuideBookingsService,
            IProfileService profileService)
        {
            _userService = userService;
            _locationService = locationService;
            _feedbackService = feedbackService;
            _guideService = guideService;
            _wishlistService = wishlistService;
            _userGuideBookingsService = userGuideBookingsService;
            _profileService = profileService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterGuide([FromBody] Users traveler)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid guide data provided." });
            if (traveler.Role_ID <= 0 || traveler.Role_ID ==0 )
            {
                traveler.Role_ID = 3;
            }

            var createdTraveler = await _userService.CreateUserAsync(traveler);
            return Ok(new { message = "Traveler registered successfully.", data = createdTraveler });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid login data provided." });

            // Simulate login processing without actual authentication
            // For example, you might just return a success message

            return Ok(new { message = "Login successful (no authentication performed)." });
        }

        // Get locations by city
        [HttpGet("locations/{cityId}")]
        public async Task<IActionResult> GetLocationsByCity(int cityId)
        {
            var locations = await _locationService.GetLocationsByCityAsync(cityId);
            if (locations == null || !locations.Any())
            {
                return NotFound($"No locations found for city ID {cityId}.");
            }
            return Ok(locations);
        }

        // Get feedbacks for a location
        [HttpGet("feedbacks/{locationId}")]
        public async Task<IActionResult> GetFeedbacksByLocation(int locationId)
        {
            var feedbacks = await _feedbackService.GetPlaceFeedbacksAsync(locationId);
            if (feedbacks == null || !feedbacks.Any())
            {
                return NotFound($"No feedbacks found for location ID {locationId}.");
            }
            return Ok(feedbacks);
        }

        // Book guide services
        [HttpPost("book-guide")]
        public async Task<IActionResult> BookGuide([FromBody] User_Guide_Bookings request)
        {
            if (request == null)
            {
                return BadRequest("Invalid booking request data.");
            }

            var result = await _userGuideBookingsService.BookGuideAsync(request);
            if (result)
            {
                return Ok("Guide booking successful.");
            }
            return BadRequest("Guide booking failed. Please check your request data and try again.");
        }

        // Save location to wishlist
        [HttpPost("wishlist")]
        public async Task<IActionResult> AddToWishlist([FromBody] Wishlist request)
        {
            if (request == null)
            {
                return BadRequest("Invalid wishlist request data.");
            }

            var result = await _wishlistService.CreateWishlistAsync(request);
            if (result != null)
            {
                return Ok("Location added to wishlist successfully.");
            }
            return BadRequest("Failed to add location to wishlist. Please try again.");
        }

        // Give feedback for a location
        [HttpPost("feedback/location")]
        public async Task<IActionResult> AddLocationFeedback([FromBody] Place_Feedbacks request)
        {
            if (request == null)
            {
                return BadRequest("Invalid feedback request data.");
            }

            var result = await _feedbackService.AddPlaceFeedbackAsync(request);
            if (result)
            {
                return Ok("Feedback for location submitted successfully.");
            }
            return BadRequest("Failed to submit feedback for location. Please try again.");
        }

        // Give feedback for a guide
        [HttpPost("feedback/guide")]
        public async Task<IActionResult> AddGuideFeedback([FromBody] Guide_Feedbacks request)
        {
            if (request == null)
            {
                return BadRequest("Invalid feedback request data.");
            }

            var result = await _feedbackService.AddGuideFeedbackAsync(request);
            if (result)
            {
                return Ok("Feedback for guide submitted successfully.");
            }
            return BadRequest("Failed to submit feedback for guide. Please try again.");
        }

        // Edit traveler profile
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] Users request)
        {
            if (request == null)
            {
                return BadRequest("Invalid profile update request data.");
            }

            var result = await _profileService.UpdateProfileAsync(request);
            if (result)
            {
                return Ok("Profile updated successfully.");
            }
            return BadRequest("Failed to update profile. Please check your request data and try again.");
        }
    }
}
