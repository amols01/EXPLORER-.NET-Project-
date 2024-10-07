using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti_.ServicesImpl
{
    public class WishlistServiceImpl : IWishlistService
    {
        private readonly TravelGuideContext _context;

        public WishlistServiceImpl(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task AddToWishlistAsync(Wishlist wishlist)
        {
            wishlist.AddedDate = DateTime.Now;
            _context.Wishlists.Add(wishlist);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Wishlist>> GetWishlistByUserAsync(int userId)
        {
            return await _context.Wishlists
                .Where(w => w.UserId == userId)
                .Include(w => w.Location)
                .ToListAsync();
        }

        public async Task<bool> RemoveFromWishlistAsync(int id)
        {
            var wishlistItem = await _context.Wishlists.FindAsync(id);
            if (wishlistItem == null)
            {
                return false;
            }

            _context.Wishlists.Remove(wishlistItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}