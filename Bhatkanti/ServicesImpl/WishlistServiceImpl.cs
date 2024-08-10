using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class WishlistServiceImpl : IWishlistService
    {
        private readonly ApplicationDbContext _context;

        public WishlistServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wishlist>> GetAllWishlistsAsync()
        {
            return await _context.Wishlists.ToListAsync();
        }

        public async Task<Wishlist> GetWishlistByIdAsync(int id)
        {
            return await _context.Wishlists.FindAsync(id);
        }

        public async Task<Wishlist> CreateWishlistAsync(Wishlist wishlist)
        {
            _context.Wishlists.Add(wishlist);
            await _context.SaveChangesAsync();
            return wishlist;
        }

        public async Task<Wishlist> UpdateWishlistAsync(Wishlist wishlist)
        {
            _context.Wishlists.Update(wishlist);
            await _context.SaveChangesAsync();
            return wishlist;
        }

        public async Task DeleteWishlistAsync(int id)
        {
            var wishlist = await _context.Wishlists.FindAsync(id);
            if (wishlist != null)
            {
                _context.Wishlists.Remove(wishlist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
