using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Add this namespace for session handling
using System.Threading.Tasks;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Guide request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _guideService.RegisterGuideAsync(request);
            if (result)
            {
                return Ok("Guide registered successfully.");
            }
            return StatusCode(500, "An error occurred while registering the guide.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] GuideLoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid login request.");
            }

            var guide = await _guideService.AuthenticateAsync(request.Email, request.Password);
            if (guide != null)
            {
                // Set the session or return the token as needed
                HttpContext.Session.SetString("GuideId", guide.GuideId.ToString());
                return Ok(guide); // Return guide or relevant info
                
            }
            return Unauthorized("Invalid email or password.");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();
            return Ok("Logged out successfully.");
        }
    }
}