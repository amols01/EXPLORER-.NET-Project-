using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IWishlistService
    {
        Task<IEnumerable<Wishlist>> GetAllWishlistsAsync();
        Task<Wishlist> GetWishlistByIdAsync(int id);
        Task<Wishlist> CreateWishlistAsync(Wishlist wishlist);
        Task<Wishlist> UpdateWishlistAsync(Wishlist wishlist);
        Task DeleteWishlistAsync(int id);
    }
}
