using Bhatkanti_.Models;

namespace Bhatkanti_.Services
{
    public interface IWishlistService
    {
        Task AddToWishlistAsync(Wishlist wishlist);
        Task<IEnumerable<Wishlist>> GetWishlistByUserAsync(int userId);
        Task<bool> RemoveFromWishlistAsync(int id);
    }
}