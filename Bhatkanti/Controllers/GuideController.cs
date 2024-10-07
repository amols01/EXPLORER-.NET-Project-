using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bhatkanti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Guide")]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService;
        private readonly IPlaceService _placeService;
        private readonly IUserService _userService;
        private readonly IPlaceImageService _placeImageService;
        private readonly IBookingPlaceGuideService _bookingPlaceGuideService;
        private readonly IUserGuideBookingsService _userGuideBookingsService;

        public GuideController(IGuideService guideService, IPlaceService placeService,
            IPlaceImageService placeImageService, IBookingPlaceGuideService bookingPlaceGuideService,
            IUserGuideBookingsService userGuideBookingsService, IUserService userService)
        {
            _guideService = guideService;
            _placeService = placeService;
            _placeImageService = placeImageService;
            _bookingPlaceGuideService = bookingPlaceGuideService;
            _userGuideBookingsService = userGuideBookingsService;
            _userService = userService;
        }

        // POST: api/Guide/Register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterGuide([FromBody] Guide guide)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid guide data provided." });
            if (guide.User.Role_ID <= 0) 
            {
                guide.User.Role_ID = 2; 
            }

            var createdGuide = await _guideService.CreateGuideAsync(guide);
            return CreatedAtAction(nameof(GetGuideById), new { id = createdGuide.Guide_ID }, new { message = "Guide registered successfully.", data = createdGuide });
        }

        [HttpGet("{guideId}/earnings")]
        public async Task<IActionResult> GetTotalEarnings(int guideId)
        {
            var totalEarnings = await _guideService.GetTotalEarningsAsync(guideId);
            return Ok(new { GuideId = guideId, TotalEarnings = totalEarnings });
        }
        // PUT: api/Guide/UpdateLocations
        [HttpPut("UpdateLocations")]
        public async Task<IActionResult> UpdateLocations([FromBody] Place place)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid location data provided." });

            var updatedPlace = await _placeService.UpdatePlaceAsync(place);
            return Ok(new { message = "Location updated successfully.", data = updatedPlace });
        }

        // POST: api/Guide/UploadDocuments
        [HttpPost("UploadDocuments")]
        public async Task<IActionResult> UploadDocuments([FromForm] Place_Images placeImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid document data provided." });

            var uploadedImage = await _placeImageService.UpdatePlaceImageAsync(placeImage);
            return Ok(new { message = "Documents uploaded successfully.", data = uploadedImage });
        }

        // GET: api/Guide/BookedTrips/{guideId}
        [HttpGet("BookedTrips/{guideId}")]
        public async Task<IActionResult> GetBookedTrips(int guideId)
        {
            var bookings = await _bookingPlaceGuideService.GetBookingsByGuideIdAsync(guideId);
            return Ok(new { message = "Booked trips retrieved successfully.", data = bookings });
        }

        // GET: api/Guide/TripHistory/{guideId}
        [HttpGet("TripHistory/{guideId}")]
        public async Task<IActionResult> GetTripHistory(int guideId)
        {
            var tripHistory = await _userGuideBookingsService. GetUserGuideBookingsByGuideIdAsync(guideId);
            return Ok(new { message = "Trip history retrieved successfully.", data = tripHistory });
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

        // GET: api/Guide/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuideById(int id)
        {
            var guide = await _guideService.GetGuideByIdAsync(id);
            if (guide == null)
                return NotFound(new { message = "Guide not found." });

            return Ok(new { message = "Guide retrieved successfully.", data = guide });
        }
    }
}