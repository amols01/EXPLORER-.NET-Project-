using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class PlaceImageServiceImpl : IPlaceImageService
    {
        private readonly ApplicationDbContext _context;

        public PlaceImageServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Place_Images>> GetAllPlaceImagesAsync()
        {
            return await _context.Place_Images.ToListAsync();
        }

        public async Task<Place_Images> GetPlaceImageByIdAsync(int id)
        {
            return await _context.Place_Images.FindAsync(id);
        }

        public async Task<Place_Images> CreatePlaceImageAsync(Place_Images placeImage)
        {
            _context.Place_Images.Add(placeImage);
            await _context.SaveChangesAsync();
            return placeImage;
        }

        public async Task<Place_Images> UpdatePlaceImageAsync(Place_Images placeImage)
        {
            _context.Place_Images.Update(placeImage);
            await _context.SaveChangesAsync();
            return placeImage;
        }

        public async Task DeletePlaceImageAsync(int id)
        {
            var placeImage = await _context.Place_Images.FindAsync(id);
            if (placeImage != null)
            {
                _context.Place_Images.Remove(placeImage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
