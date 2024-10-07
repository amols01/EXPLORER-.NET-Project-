using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bhatkanti_.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserGuideBookingService _bookingService;

        public UserController(IUserService userService, IUserGuideBookingService bookingService)
        {
            _userService = userService;
            _bookingService = bookingService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            request.Timestamp = DateTime.UtcNow;
            var result = await _userService.RegisterUserAsync(request);
            if (result)
            {
                return Ok("User registered successfully.");
            }
            return StatusCode(500, "An error occurred while registering the user.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] GuideLoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid login request.");
            }

            var user = await _userService.AuthenticateUserAsync(request.Email, request.Password);
            if (user != null)
            {
                // You can return the user data or set a session/token as needed
                return Ok(user);
            }
            return Unauthorized("Invalid email or password.");
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] User request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var existingUser = await _userService.GetUserByIdAsync(userId);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            // Update user fields
            existingUser.Username = request.Username;
            existingUser.Email = request.Email;
            existingUser.PhoneNumber = request.PhoneNumber;
            existingUser.Password = request.Password;  // Consider hashing in production

            var result = await _userService.UpdateUserAsync(existingUser);
            if (result)
            {
                return Ok("User updated successfully.");
            }
            return StatusCode(500, "An error occurred while updating the user.");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (result)
            {
                return Ok("User deleted successfully.");
            }
            return NotFound("User not found.");
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookGuide([FromBody] UserGuideBooking booking)
        {
            if (booking == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid booking data.");
            }

            var result = await _bookingService.BookGuideAsync(booking);
            if (result)
            {
                return Ok("Guide booked successfully.");
            }
            return StatusCode(500, "An error occurred while booking the guide.");
        }

        [HttpDelete("cancel/{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var result = await _bookingService.CancelBookingAsync(id);
            if (result)
            {
                return Ok("Booking canceled successfully.");
            }
            return NotFound("Booking not found.");
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking != null)
            {
                return Ok(booking);
            }
            return NotFound("Booking not found.");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UserGuideBooking booking)
        {
            if (booking == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid booking data.");
            }

            var result = await _bookingService.UpdateBookingAsync(id, booking);
            if (result)
            {
                return Ok("Booking updated successfully.");
            }
            return NotFound("Booking not found.");
        }
    }
}