using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bhatkanti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly IMemoryCache _cache;

        public UserController(IUserService usersService, IMemoryCache cache)
        {
            _usersService = usersService;
            _cache = cache;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Users user)
        {
            // Validate model state based on data annotations
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (user.Role_ID <= 0)
            {
                return BadRequest("The Role field is required.");
            }

            if (await _usersService.GetUserByEmailAsync(user.Email) != null)
            {
                return BadRequest("User with this email already exists.");
            }

            var createdUser = await _usersService.CreateUserAsync(user);

            // Manually build the URL for the created resource
            var url = Url.Action(nameof(GetUser), new { userId = createdUser.User_ID });

            return Created(url, createdUser);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var cacheKey = $"User_{userId}";
            if (_cache.TryGetValue(cacheKey, out Users user))
            {
                return Ok(user);
            }

            user = await _usersService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _cache.Set(cacheKey, user, TimeSpan.FromMinutes(30));
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid login request.");
            }

            var user = await _usersService.AuthenticateAsync(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.User_ID.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Role_ID.ToString()) // Assuming Role_ID is mapped to roles
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            var cacheKey = $"User_{user.User_ID}";
            _cache.Set(cacheKey, user, TimeSpan.FromMinutes(30));

            return Ok(new { Message = "Login successful" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.User_ID)
            {
                return BadRequest("User ID mismatch.");
            }

            var updatedUser = await _usersService.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                return NotFound("User not found.");
            }

            return Ok(new { Message = "User updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            await _usersService.DeleteUserAsync(id);
            return Ok(new { Message = "User deleted successfully." });
        }
    }

    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
