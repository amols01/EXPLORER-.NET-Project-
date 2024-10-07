using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        // POST: api/Wishlist
        [HttpPost]
        public async Task<IActionResult> AddToWishlist([FromBody] Wishlist wishlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _wishlistService.AddToWishlistAsync(wishlist);
            return Ok(wishlist);
        }

        // GET: api/Wishlist/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWishlistByUser(int userId)
        {
            var wishlist = await _wishlistService.GetWishlistByUserAsync(userId);
            if (wishlist == null || !wishlist.Any())
            {
                return NotFound();
            }
            return Ok(wishlist);
        }

        // DELETE: api/Wishlist/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromWishlist(int id)
        {
            var success = await _wishlistService.RemoveFromWishlistAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}