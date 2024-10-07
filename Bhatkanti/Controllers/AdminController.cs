using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bhatkanti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGuideService _guideService;
        private readonly IFeedbackService _feedbackService;
        private readonly ICityService _cityService;
        private readonly IPlaceService _placeService;
        private readonly IBookingPlaceGuideService _bookingPlaceGuideService;
        private readonly IPlaceImageService _placeImageService;

        public AdminController(IUserService userService, IGuideService guideService,
            IFeedbackService feedbackService, ICityService cityService,
            IPlaceService placeService, IBookingPlaceGuideService bookingPlaceGuideService,
            IPlaceImageService placeImageService)
        {
            _userService = userService;
            _guideService = guideService;
            _feedbackService = feedbackService;
            _cityService = cityService;
            _placeService = placeService;
            _bookingPlaceGuideService = bookingPlaceGuideService;
            _placeImageService = placeImageService;
        }

        // GET: api/Admin/Users
        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/Admin/Guides
        [HttpGet("Guides")]
        public async Task<IActionResult> GetAllGuides()
        {
            var guides = await _guideService.GetAllGuidesAsync();
            return Ok(guides);
        }

        // GET: api/Admin/Feedbacks
        //[HttpGet("Feedbacks")]
        //public async Task<IActionResult> GetAllFeedbacks()
        //{
        //    var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
        //    return Ok(feedbacks);
        //}

        // PUT: api/Admin/Feedbacks/{id}
        //[HttpPut("Feedbacks/{id}")]
        //public async Task<IActionResult> EditFeedback(int id, [FromBody] Feedback feedback)
        //{
        //    if (id != feedback.Feedback_ID)
        //        return BadRequest();

        //    var updatedFeedback = await _feedbackService.UpdateFeedbackAsync(feedback);
        //    return Ok(updatedFeedback);
        //}

        //// DELETE: api/Admin/Feedbacks/{id}
        //[HttpDelete("Feedbacks/{id}")]
        //public async Task<IActionResult> DeleteFeedback(int id)
        //{
        //    await _feedbackService.DeleteFeedbackAsync(id);
        //    return NoContent();
        //}

        //// POST: api/Admin/VerifyGuide/{guideId}
        //[HttpPost("VerifyGuide/{guideId}")]
        //public async Task<IActionResult> VerifyGuide(int guideId)
        //{
        //    var guide = await _guideService.VerifyGuideAsync(guideId);
        //    return Ok(guide);
        //}

        // POST: api/Admin/ApproveGuideBooking/{bookingId}
        //[HttpPost("ApproveGuideBooking/{bookingId}")]
        //public async Task<IActionResult> ApproveGuideBooking(int bookingId)
        //{
        //    var booking = await _bookingPlaceGuideService.ApproveBookingAsync(bookingId);
        //    return Ok(booking);
        //}

        // GET: api/Admin/BookingHistory
        [HttpGet("BookingHistory")]
        public async Task<IActionResult> GetAllBookingHistory()
        {
            var bookings = await _bookingPlaceGuideService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/Admin/Cities
        [HttpGet("Cities")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        // GET: api/Admin/Locations
        [HttpGet("Locations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _placeService.GetAllPlacesAsync();
            return Ok(locations);
        }

        // PUT: api/Admin/City/{id}
        [HttpPut("City/{id}")]
        public async Task<IActionResult> EditCity(int id, [FromBody] Cities city)
        {
            if (id != city.City_ID)
                return BadRequest();

            var updatedCity = await _cityService.UpdateCityAsync(city);
            return Ok(updatedCity);
        }

        // DELETE: api/Admin/City/{id}
        [HttpDelete("City/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            await _cityService.DeleteCityAsync(id);
            return NoContent();
        }

        // PUT: api/Admin/Location/{id}
        [HttpPut("Location/{id}")]
        public async Task<IActionResult> EditLocation(int id, [FromBody] Place place)
        {
            if (id != place.Place_ID)
                return BadRequest();

            var updatedLocation = await _placeService.UpdatePlaceAsync(place);
            return Ok(updatedLocation);
        }

        // DELETE: api/Admin/Location/{id}]
        [HttpDelete("Location/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _placeService.DeletePlaceAsync(id);
            return NoContent();
        }

        // POST: api/Admin/AddLocationImage
        [HttpPost("AddLocationImage")]
        //public async Task<IActionResult> AddLocationImage([FromForm] Place_Images placeImage)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var addedImage = await _placeImageService.UploadImageAsync(placeImage);
        //    return Ok(addedImage);
        //}

        // POST: api/Admin/Register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Users user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Ensure the role is set to Admin
            user.Role_ID = 1; // Assuming 1 is the Role_ID for Admin
            var registeredUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetAllUsers), new { id = registeredUser.User_ID }, registeredUser);
        }
    }
}
