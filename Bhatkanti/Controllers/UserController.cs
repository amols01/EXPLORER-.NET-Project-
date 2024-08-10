using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

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
        public async Task<IActionResult> Register(Users user)
        {
            // Check if required fields are present
            if (user.Role_ID <= 0)
            {
                return BadRequest("The Role field is required.");
            }

            if (await _usersService.GetUserByEmailAsync(user.Email) != null)
            {
                return BadRequest("User with this email already exists.");
            }

            // Initialize collections if not provided
            user.Guides ??= new List<Guide>();
            user.Bills ??= new List<Bill>();
            user.Wishlists ??= new List<Wishlist>();
            user.FeedbackImages ??= new List<Feedback_Image>();
            user.PlaceFeedbacks ??= new List<Place_Feedbacks>();
            user.Helps ??= new List<Help>();
            user.Images ??= new List<Images>();

            var createdUser = await _usersService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.User_ID }, createdUser);
        }

        // POST: api/user/login
       

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var users = await _usersService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Login request is required.");
            }

            var user = await _usersService.AuthenticateAsync(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.User_ID.ToString()), // ID claim
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty) // Email claim
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Set authentication cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            // Cache user details
            var cacheKey = $"User_{user.User_ID}";
            _cache.Set(cacheKey, user, TimeSpan.FromMinutes(30)); // Cache for 30 minutes

            return Ok(new { Message = "Login successful" });
        }
        // GET: api/user/{id}
        /*  [HttpGet("{id}")]
          public async Task<ActionResult<Users>> GetUser(int id)
          {
              var user = await _usersService.GetUserByIdAsync(id);
              if (user == null)
              {
                  return NotFound();
              }
              return Ok(user);
          } */

        [HttpGet("user/{userId}")]
        public IActionResult GetUser(int userId)
        {
            var cacheKey = $"User_{userId}";
            if (_cache.TryGetValue(cacheKey, out Users user))
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found in cache.");
            }
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Users user)
        {
            if (id != user.User_ID)
            {
                return BadRequest("User ID mismatch.");
            }

            var updated = await _usersService.UpdateUserAsync(user);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "User updated successfully." });
        }


        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _usersService.DeleteUserAsync(id);

            return Ok(new { Message = "User deleted successfully." });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
