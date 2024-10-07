using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bhatkanti.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class WishlistController : ControllerBase
    //{
    //    // GET: api/<WishlistController>
    //    [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/<WishlistController>/5
    //    [HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<WishlistController>
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/<WishlistController>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE api/<WishlistController>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    // }
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlists()
        {
            var wishlists = await _wishlistService.GetAllWishlistsAsync();
            return Ok(wishlists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
            var wishlist = await _wishlistService.GetWishlistByIdAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return Ok(wishlist);
        }

        [HttpPost]
        public async Task<ActionResult<Wishlist>> CreateWishlist(Wishlist wishlist)
        {
            var createdWishlist = await _wishlistService.CreateWishlistAsync(wishlist);
            return CreatedAtAction(nameof(GetWishlist), new { id = createdWishlist.Wishlist_ID }, createdWishlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWishlist(int id, Wishlist wishlist)
        {
            if (id != wishlist.Wishlist_ID)
            {
                return BadRequest();
            }

            var updated = await _wishlistService.UpdateWishlistAsync(wishlist);
            if (updated==null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            var wishlist = await _wishlistService.GetWishlistByIdAsync(id);
            if (wishlist == null)
            {
                return NotFound(new { Message = $"Wishlist with ID {id} not found." });
            }

            await _wishlistService.DeleteWishlistAsync(id);

            return Ok(new { Message = $"Wishlist with ID {id} has been deleted successfully." });
        }
    }

}
