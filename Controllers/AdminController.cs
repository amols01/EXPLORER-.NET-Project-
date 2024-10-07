using Microsoft.AspNetCore.Mvc;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;

namespace Bhatkanti_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        // GET: api/admin/{email}
        [HttpGet("{email}")]
        public async Task<ActionResult<Admin>> GetAdminByEmail(string email)
        {
            var admin = await _adminService.GetAdminByEmailAsync(email);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid login request");
            }

            var isAuthenticated = await _adminService.AuthenticateAsync(request.Email, request.Password);
            if (!isAuthenticated)
            {
                return Unauthorized("Invalid email or password");
            }

            // Set session value
            HttpContext.Session.SetString("AdminEmail", request.Email);

            return Ok(new { Message = "Login successful" });
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminEmail");
            return Ok(new { Message = "Logout successful" });
        }

        // POST: api/admin
        [HttpPost("register")]
        public async Task<ActionResult> CreateAdmin(Admin admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin data is null");
            }

            await _adminService.CreateAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdminByEmail), new { email = admin.Email }, admin);
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteAdmin(string email)
        {
            var success = await _adminService.DeleteAdminAsync(email);
            if (!success)
            {
                return BadRequest("Admin Not Found");
            }
            return NoContent();
        }
        [HttpPost("guides")]
        public async Task<IActionResult> CreateGuide([FromBody] Guide request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _adminService.CreateGuideAsync(request);
            if (result)
            {
                return CreatedAtAction(nameof(GetGuideById), new { guideId = request.GuideId }, request);
            }
            return StatusCode(500, "An error occurred while creating the guide.");
        }

        [HttpGet("guides/{guideId}")]
        public async Task<IActionResult> GetGuideById(int guideId)
        {
            var guide = await _adminService.GetGuideByIdAsync(guideId);
            if (guide == null)
            {
                return NotFound();
            }
            return Ok(guide);
        }

        [HttpGet("guides")]
        public async Task<IActionResult> GetAllGuides()
        {
            var guides = await _adminService.GetAllGuidesAsync();
            return Ok(guides);
        }

        [HttpPut("guides/{guideId}")]
        public async Task<IActionResult> UpdateGuide(int guideId, [FromBody] Guide request)
        {
            if (request == null || request.GuideId != guideId || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var existingGuide = await _adminService.GetGuideByIdAsync(guideId);
            if (existingGuide == null)
            {
                return NotFound();
            }

            var result = await _adminService.UpdateGuideAsync(request);
            if (result)
            {
                return NoContent();
            }
            return StatusCode(500, "An error occurred while updating the guide.");
        }

        [HttpDelete("guides/{guideId}")]
        public async Task<IActionResult> DeleteGuide(int guideId)
        {
            var existingGuide = await _adminService.GetGuideByIdAsync(guideId);
            if (existingGuide == null)
            {
                return NotFound();
            }

            var result = await _adminService.DeleteGuideAsync(guideId);
            if (result)
            {
                return NoContent();
            }
            return StatusCode(500, "An error occurred while deleting the guide.");
        }
    }
}
